using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class TrackFootprintsHandler
    {
        private readonly Settings _settings;
        private readonly List<TrackFootprint> _footprintsList;

        public TrackFootprintsHandler(Settings settings)
        {
            _settings = settings;
            _footprintsList = new List<TrackFootprint>();

            // Se você precisar de algum código para lidar com eventos de clique na interface do usuário, adicione aqui.
        }

        public void AddFootprint(int id, double posX, double posY, string name)
        {
            if (_footprintsList.Any(fp => fp.Id == id)) return;

            var newFootprint = new TrackFootprint(id, posX, posY, name);
            _footprintsList.Add(newFootprint);
        }

        public void RemoveFootprint(int id)
        {
            _footprintsList.RemoveAll(fp => fp.Id == id);
        }

        public void UpdateFootprintPosition(int id, double posX, double posY)
        {
            var existingFootprint = _footprintsList.FirstOrDefault(fp => fp.Id == id);
            if (existingFootprint != null)
            {
                existingFootprint.PosX = posX;
                existingFootprint.PosY = posY;
            }
        }

        public List<TrackFootprint> GetFootprintsList()
        {
            return new List<TrackFootprint>(_footprintsList);
        }
    }
}
