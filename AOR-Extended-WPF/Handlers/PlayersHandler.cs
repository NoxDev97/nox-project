using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using AOR_Extended_WPF.Drawings;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class PlayersHandler
    {
        private readonly Settings _settings;
        private readonly List<Player> _playersInRange;
        private readonly Player _localPlayer;
        private readonly List<string> _filteredPlayers;
        private readonly List<string> _filteredGuilds;
        private readonly List<string> _filteredAlliances;
        private readonly List<string> _alreadyFilteredPlayers;
        private readonly Dictionary<int, Spell> _spellInfo;
        private readonly Dictionary<string, DateTime> _castedSpells;

        public PlayersHandler(Settings settings, Dictionary<int, Spell> spellsInfo)
        {
            _settings = settings;
            _playersInRange = new List<Player>();
            _localPlayer = new Player();
            _filteredPlayers = new List<string>();
            _filteredGuilds = new List<string>();
            _filteredAlliances = new List<string>();
            _alreadyFilteredPlayers = new List<string>();
            _spellInfo = spellsInfo;
            _castedSpells = new Dictionary<string, DateTime>();

            foreach (var element in _settings.IgnoreList)
            {
                var name = element;
                switch (element)
                {
                    case "Player":
                        _filteredPlayers.Add(name);
                        break;
                    case "Guild":
                        _filteredGuilds.Add(name);
                        break;
                    case "Alliance":
                        _filteredAlliances.Add(name);
                        break;
                    default:
                        _filteredPlayers.Add(name);
                        break;
                }
            }
        }

        public List<Player> GetPlayersInRange()
        {
            return new List<Player>(_playersInRange);
        }

        public void UpdateItems(int id, object[] parameters)
        {
            List<string> items = null;

            try
            {
                items = parameters[2] as List<string>;
            }
            catch
            {
                items = null;
            }

            if (items != null)
            {
                foreach (var player in _playersInRange)
                {
                    if (player.Id == id)
                    {
                        player.Items = items;
                    }
                }
            }
        }

        public void HandleNewPlayerEvent(object[] parameters)
        {
            if (!_settings.SettingOnOff) return;

            var id = Convert.ToInt32(parameters[0]);
            var nickname = parameters[1].ToString();

            if (_alreadyFilteredPlayers.Contains(nickname.ToUpper())) return;

            if (_filteredPlayers.Contains(nickname.ToUpper()))
            {
                _alreadyFilteredPlayers.Add(nickname.ToUpper());
            }

            var guildName = parameters[8].ToString();

            if (_filteredGuilds.Contains(guildName.ToUpper()))
            {
                _alreadyFilteredPlayers.Add(nickname.ToUpper());
            }

            var alliance = parameters[49].ToString();

            if (_filteredAlliances.Contains(alliance.ToUpper()))
            {
                _alreadyFilteredPlayers.Add(nickname.ToUpper());
            }

            var positionArray = parameters[14] as double[];
            var posX = positionArray[0];
            var posY = positionArray[1];

            var currentHealth = Convert.ToDouble(parameters[20]);
            var initialHealth = Convert.ToDouble(parameters[21]);

            var items = parameters[38] as List<string>;
            var flagId = Convert.ToInt32(parameters[51]);

            var spells = parameters[41] as List<string>;

            AddPlayer(posX, posY, id, nickname, guildName, currentHealth, initialHealth, items, flagId, spells, alliance);
        }

        public void HandleMountedPlayerEvent(int id, object[] parameters)
        {
            var ten = parameters[10];
            var mounted = parameters[11];

            if (mounted.ToString() == "true" || (bool)mounted)
            {
                UpdatePlayerMounted(id, true);
            }
            else if (ten.ToString() == "-1")
            {
                UpdatePlayerMounted(id, true);
            }
            else
            {
                UpdatePlayerMounted(id, false);
            }
        }

        public void AddPlayer(double posX, double posY, int id, string nickname, string guildName, double currentHealth, double initialHealth, List<string> items, int flagId, List<string> spells, string alliance)
        {
            if (_playersInRange.Any(p => p.Id == id)) return;

            var newPlayer = new Player(posX, posY, id, nickname, guildName, currentHealth, initialHealth, items, flagId, new SpellSlots(), alliance);
            _playersInRange.Add(newPlayer);

            if (!_settings.SettingSound) return;

            var audio = new SoundPlayer("player.mp3");
            var volume = 1.0; // Implement a method to set volume if needed
            // audio.Volume = volume; // Adjust if needed
            audio.Play();
        }

        public void UpdateLocalPlayerNextPosition(double posX, double posY)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayerMounted(int id, bool mounted)
        {
            foreach (var player in _playersInRange)
            {
                if (player.Id == id)
                {
                    player.SetMounted(mounted);
                    break;
                }
            }
        }

        public void RemovePlayer(int id)
        {
            _playersInRange.RemoveAll(player => player.Id == id);
        }

        public void UpdateLocalPlayerPosition(double posX, double posY)
        {
            _localPlayer.PosX = posX;
            _localPlayer.PosY = posY;
        }

        public double LocalPlayerPosX()
        {
            return _localPlayer.PosX;
        }

        public double LocalPlayerPosY()
        {
            return _localPlayer.PosY;
        }

        public void UpdatePlayerPosition(int id, double posX, double posY)
        {
            foreach (var player in _playersInRange)
            {
                if (player.Id == id)
                {
                    player.PosX = posX;
                    player.PosY = posY;
                }
            }
        }

        public void UpdatePlayerHealth(object[] parameters)
        {
            var id = Convert.ToInt32(parameters[0]);
            var player = _playersInRange.FirstOrDefault(p => p.Id == id);

            if (player == null) return;

            player.CurrentHealth = Convert.ToDouble(parameters[2]);
            player.InitialHealth = Convert.ToDouble(parameters[3]);
        }

        public void UpdateSpells(int playerId, object[] parameters)
        {
            var spells = new SpellSlots(65535, 65535, 65535, 65535, 65535, 65535);
            try
            {
                var spellData = parameters[6] as int[];
                if (spellData != null)
                {
                    spells = new SpellSlots(spellData[0], spellData[1], spellData[2], spellData[4], spellData[3], spellData[5]);
                }
            }
            catch
            {
                spells = new SpellSlots(65535, 65535, 65535, 65535, 65535, 65535);
            }

            foreach (var player in _playersInRange)
            {
                if (player.Id == playerId)
                {
                    player.Spells = spells;
                }
            }
        }

        public void HandleCastSpell(object[] parameters)
        {
            var playerId = Convert.ToInt32(parameters[0]);
            var spellId = Convert.ToInt32(parameters[1]);

            if (_spellInfo.ContainsKey(spellId))
            {
                var spell = _spellInfo[spellId];
                var expirationTime = DateTime.Now.AddSeconds(spell.Cooldown);
                _castedSpells[$"{playerId}_{(spell.ParentId.HasValue ? spell.ParentId.Value : spell.Id)}"] = expirationTime;
            }
        }

        public void RemoveSpellsWithoutCooldown()
        {
            var now = DateTime.Now;
            var keysToRemove = _castedSpells.Where(pair => pair.Value < now).Select(pair => pair.Key).ToList();
            foreach (var key in keysToRemove)
            {
                _castedSpells.Remove(key);
            }
        }

        public void Clear()
        {
            _playersInRange.Clear();
        }
    }
}
