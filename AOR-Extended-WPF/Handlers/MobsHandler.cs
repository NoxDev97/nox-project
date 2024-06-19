using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Utils; // Adicione esta linha para referenciar o namespace da classe Settings
using AOR_Extended_WPF.Handlers; // Adicione esta linha para referenciar a classe Mist

namespace AOR_Extended_WPF.Handlers
{
    public class MobsHandler
    {
        private Settings _settings;
        private List<Mob> _mobsList;
        private List<Mist> _mistList;
        private Dictionary<int, string[]> _mobinfo;
        private List<Mob> _harvestablesNotGood;

        public MobsHandler(Settings settings)
        {
            _settings = settings;
            _mobsList = new List<Mob>();
            _mistList = new List<Mist>();
            _mobinfo = new Dictionary<int, string[]>();
            _harvestablesNotGood = new List<Mob>();
        }

        public void UpdateMobInfo(Dictionary<int, string[]> newData)
        {
            _mobinfo = newData;
        }

        public void Clear()
        {
            _mobsList.Clear();
            _mistList.Clear();
        }

        public void NewMobEvent(object[] parameters)
        {
            int id = Convert.ToInt32(parameters[0]);
            int typeId = Convert.ToInt32(parameters[1]);
            var loc = (double[])parameters[7];
            double posX = loc[0];
            double posY = loc[1];

            double exp = 0;
            try { exp = Convert.ToDouble(parameters[13]); }
            catch { exp = 0; }

            string name = null;
            try { name = parameters[32]?.ToString(); }
            catch { try { name = parameters[31]?.ToString(); } catch { name = null; } }

            int enchant = 0;
            try { enchant = Convert.ToInt32(parameters[33]); }
            catch { enchant = 0; }

            int rarity = 1;
            try { rarity = Convert.ToInt32(parameters[19]); }
            catch { rarity = 1; }

            if (name != null) AddMist(id, posX, posY, name, enchant);
            else AddEnemy(id, typeId, posX, posY, exp, enchant, rarity);
        }

        public void AddEnemy(int id, int typeId, double posX, double posY, double health, int enchant, int rarity)
        {
            if (_mobsList.Any(existingMob => existingMob.Id == id)) return;
            if (_harvestablesNotGood.Any(existingMob => existingMob.Id == id)) return;

            var newMob = new Mob(id, typeId, posX, posY, health, enchant, rarity);

            if (newMob.Health < _settings.MinHP) return;

            if (_mobinfo.ContainsKey(typeId))
            {
                var mobsInfo = _mobinfo[typeId];
                newMob.Tier = Convert.ToInt32(mobsInfo[0]);
                newMob.Type = (EnemyType)Enum.Parse(typeof(EnemyType), mobsInfo[1]);
                newMob.Name = mobsInfo[2];

                if (!ValidateEnemyType(newMob)) return;
            }
            else if (!_settings.ShowUnmanagedEnemies) return;

            _mobsList.Add(newMob);
        }

        private bool ValidateEnemyType(Mob mob)
        {
            switch (mob.Type)
            {
                case EnemyType.LivingSkinnable:
                    if (!_settings.HarvestingLivingHide[$"e{mob.EnchantmentLevel}"][mob.Tier - 1])
                    {
                        _harvestablesNotGood.Add(mob);
                        return false;
                    }
                    break;
                case EnemyType.LivingHarvestable:
                    if (!ValidateHarvestableType(mob))
                    {
                        _harvestablesNotGood.Add(mob);
                        return false;
                    }
                    break;
                case EnemyType.Enemy:
                case EnemyType.Boss:
                    if (!_settings.EnemyLevels[(int)mob.Type - (int)EnemyType.Enemy]) return false;
                    break;
                case EnemyType.Drone:
                    if (!_settings.AvaloneDrones) return false;
                    break;
                case EnemyType.MistBoss:
                    if (!ValidateMistBossType(mob)) return false;
                    break;
                case EnemyType.Events:
                    if (!_settings.ShowEventEnemies) return false;
                    break;
                default:
                    if (!_settings.ShowUnmanagedEnemies) return false;
                    break;
            }
            return true;
        }

        private bool ValidateHarvestableType(Mob mob)
        {
            switch (mob.Name.ToLower())
            {
                case "fiber":
                    return _settings.HarvestingLivingFiber[$"e{mob.EnchantmentLevel}"][mob.Tier - 1];
                case "hide":
                    return _settings.HarvestingLivingHide[$"e{mob.EnchantmentLevel}"][mob.Tier - 1];
                case "logs":
                    return _settings.HarvestingLivingWood[$"e{mob.EnchantmentLevel}"][mob.Tier - 1];
                case "ore":
                    return _settings.HarvestingLivingOre[$"e{mob.EnchantmentLevel}"][mob.Tier - 1];
                case "rock":
                    return _settings.HarvestingLivingRock[$"e{mob.EnchantmentLevel}"][mob.Tier - 1];
                default:
                    return false;
            }
        }

        private bool ValidateMistBossType(Mob mob)
        {
            switch (mob.Name.ToUpper())
            {
                case "CRYSTALSPIDER":
                    return _settings.BossCrystalSpider;
                case "FAIRYDRAGON":
                    return _settings.BossFairyDragon;
                case "VEILWEAVER":
                    return _settings.BossVeilWeaver;
                case "GRIFFIN":
                    return _settings.BossGriffin;
                default:
                    return false;
            }
        }

        public void RemoveMob(int id)
        {
            var mobCount = _mobsList.Count;
            _mobsList = _mobsList.Where(m => m.Id != id).ToList();
            if (_mobsList.Count < mobCount) return;

            _harvestablesNotGood = _harvestablesNotGood.Where(m => m.Id != id).ToList();
        }

        public void UpdateMobPosition(int id, double posX, double posY)
        {
            var mob = _mobsList.FirstOrDefault(m => m.Id == id);
            if (mob != null)
            {
                mob.PosX = posX;
                mob.PosY = posY;
            }
        }

        public void UpdateEnchantEvent(object[] parameters)
        {
            int mobId = Convert.ToInt32(parameters[0]);
            int enchantmentLevel = Convert.ToInt32(parameters[1]);

            var mob = _mobsList.FirstOrDefault(m => m.Id == mobId) ?? _harvestablesNotGood.FirstOrDefault(m => m.Id == mobId);
            if (mob != null)
            {
                mob.EnchantmentLevel = enchantmentLevel;
                if (ValidateEnemyType(mob))
                {
                    _mobsList.Add(mob);
                    _harvestablesNotGood = _harvestablesNotGood.Where(m => m.Id != mob.Id).ToList();
                }
            }
        }

        public List<Mob> GetMobList()
        {
            return new List<Mob>(_mobsList);
        }

        public void AddMist(int id, double posX, double posY, string name, int enchant)
        {
            if (_mistList.Any(existingMist => existingMist.Id == id)) return;
            var newMist = new Mist(id, posX, posY, name, enchant);
            _mistList.Add(newMist);
        }

        public void RemoveMist(int id)
        {
            _mistList = _mistList.Where(m => m.Id != id).ToList();
        }

        public void UpdateMistPosition(int id, double posX, double posY)
        {
            var existingMist = _mistList.FirstOrDefault(m => m.Id == id);
            if (existingMist != null)
            {
                existingMist.PosX = posX;
                existingMist.PosY = posY;
            }
        }

        public void UpdateMistEnchantmentLevel(int id, int enchantmentLevel)
        {
            var existingMist = _mistList.FirstOrDefault(m => m.Id == id);
            if (existingMist != null)
            {
                existingMist.Enchant = enchantmentLevel;
            }
        }
    }
}
