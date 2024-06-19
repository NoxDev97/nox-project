using AOR_Extended_WPF.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using AOR_Extended_WPF.Drawings;

namespace AOR_Extended_WPF.Utils
{
    public class Utils
    {
        private readonly Settings _settings;
        private readonly PlayersHandler _playersHandler;
        private readonly MobsHandler _mobsHandler;
        private readonly WispCageHandler _wispCageHandler;
        private readonly FishingHandler _fishingHandler;
        private readonly TrackFootprintsHandler _trackFootprintsHandler;
        private readonly HarvestablesHandler _harvestablesHandler;
        private readonly DungeonsHandler _dungeonsHandler;
        private readonly ChestsHandler _chestsHandler;

        private double _lpX = 0.0;
        private double _lpY = 0.0;
        private DispatcherTimer _gameLoopTimer;
        private DateTime _previousTime;

        public Utils()
        {
            _settings = new Settings();

            // Inicialize o spellsInfo como um dicionário
            var spellsInfo = new Dictionary<int, Spell>();
            // Popule o spellsInfo com os dados necessários
            // ...

            // Initialize your handlers
            _playersHandler = new PlayersHandler(_settings, spellsInfo);
            _mobsHandler = new MobsHandler(_settings);
            _wispCageHandler = new WispCageHandler(_settings);
            _fishingHandler = new FishingHandler(_settings);
            _trackFootprintsHandler = new TrackFootprintsHandler(_settings);
            _harvestablesHandler = new HarvestablesHandler(_settings);
            _dungeonsHandler = new DungeonsHandler(_settings);
            _chestsHandler = new ChestsHandler();

            // Initialize game loop timer
            _gameLoopTimer = new DispatcherTimer();
            _gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16); // Roughly 60 FPS
            _gameLoopTimer.Tick += GameLoop;
            _previousTime = DateTime.Now;

            // Start game loop
            _gameLoopTimer.Start();
        }

        public void OnEvent(Dictionary<string, object> parameters)
        {
            int id = Convert.ToInt32(parameters["id"]);
            string eventCode = parameters["eventCode"].ToString();

            switch (eventCode)
            {
                case "NewHuntTrack":
                    double trackPosX = Convert.ToDouble(((object[])parameters["pos"])[0]);
                    double trackPosY = Convert.ToDouble(((object[])parameters["pos"])[1]);
                    string name = parameters["name"].ToString();
                    _trackFootprintsHandler.AddFootprint(id, trackPosX, trackPosY, name);
                    break;

                case "Leave":
                    _playersHandler.RemovePlayer(id);
                    _mobsHandler.RemoveMist(id);
                    _mobsHandler.RemoveMob(id);
                    _dungeonsHandler.RemoveDungeon(id);
                    _chestsHandler.RemoveChest(id);
                    _fishingHandler.RemoveFish(id);
                    _trackFootprintsHandler.RemoveFootprint(id);
                    break;

                case "Move":
                    double posX = Convert.ToDouble(parameters["posX"]);
                    double posY = Convert.ToDouble(parameters["posY"]);
                    _playersHandler.UpdatePlayerPosition(id, posX, posY);
                    _mobsHandler.UpdateMistPosition(id, posX, posY);
                    _mobsHandler.UpdateMobPosition(id, posX, posY);
                    _trackFootprintsHandler.UpdateFootprintPosition(id, posX, posY);
                    break;

                case "NewCharacter":
                    _playersHandler.HandleNewPlayerEvent(parameters.Values.ToArray<object>());
                    break;

                case "NewSimpleHarvestableObjectList":
                    _harvestablesHandler.NewSimpleHarvestableObject(parameters.Values.ToArray<object>());
                    break;

                case "NewHarvestableObject":
                    _harvestablesHandler.NewHarvestableObject(id, parameters.Values.ToArray<object>());
                    break;

                case "HarvestableChangeState":
                    _harvestablesHandler.HarvestUpdateEvent(parameters.Values.ToArray<object>());
                    break;

                case "HarvestFinished":
                    _harvestablesHandler.HarvestFinished(parameters.Values.ToArray<object>());
                    break;

                case "MobChangeState":
                    _mobsHandler.UpdateEnchantEvent(parameters.Values.ToArray<object>());
                    break;

                case "RegenerationHealthChanged":
                    _playersHandler.UpdatePlayerHealth(parameters.Values.ToArray<object>());
                    break;

                case "CharacterEquipmentChanged":
                    _playersHandler.UpdateItems(id, parameters.Values.ToArray<object>());
                    _playersHandler.UpdateSpells(id, parameters.Values.ToArray<object>());
                    break;

                case "NewMob":
                    _mobsHandler.NewMobEvent(parameters.Values.ToArray<object>());
                    break;

                case "Mounted":
                    _playersHandler.HandleMountedPlayerEvent(id, parameters.Values.ToArray<object>());
                    break;

                case "NewRandomDungeonExit":
                    _dungeonsHandler.DungeonEvent(parameters.Values.ToArray<object>().ToList()); ;
                    break;

                case "NewLootChest":
                    _chestsHandler.AddChestEvent(parameters.Values.ToArray<object>().ToList()); ;
                    break;

                case "NewMistsCagedWisp":
                    _wispCageHandler.NewCageEvent(parameters.Values.ToArray<object>());
                    break;

                case "MistsWispCageOpened":
                    _wispCageHandler.CageOpenedEvent(parameters.Values.ToArray<object>());
                    break;

                case "CastStart":
                    _playersHandler.HandleCastSpell(parameters.Values.ToArray<object>());
                    break;

                case "NewFishingZoneObject":
                    _fishingHandler.NewFishEvent(parameters.Values.ToArray<object>());
                    break;

                case "FishingFinished":
                    _fishingHandler.FishingEnd(parameters.Values.ToArray<object>());
                    break;

                default:
                    break;
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            Update();
            Render();
        }

        private void Update()
        {
            var currentTime = DateTime.Now;
            var deltaTime = (currentTime - _previousTime).TotalMilliseconds;
            var t = Math.Min(1, deltaTime / 100);

            if (_settings.ShowMapBackground)
            {
                // Implement your map drawing interpolation here
            }

            _harvestablesHandler.RemoveNotInRange(_lpX, _lpY);
            // Implement other update logic here

            _previousTime = currentTime;
        }

        private void Render()
        {
            // Implement your render logic here
        }
    }
}
