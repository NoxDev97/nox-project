using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Drawings;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class Cage
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string Name { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public Cage(int id, double posX, double posY, string name)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Name = name;
            HX = 0;
            HY = 0;
        }
    }

    public class WispCageHandler
    {
        private readonly Settings _settings;
        private readonly List<Cage> _cages;

        public WispCageHandler(Settings settings)
        {
            _settings = settings;
            _cages = new List<Cage>();
        }

        public void NewCageEvent(object[] parameters)
        {
            if (!_settings.WispCage || parameters[4] != null) return;

            var id = Convert.ToInt32(parameters[0]);

            if (_cages.Any(c => c.Id == id)) return;

            var posX = Convert.ToDouble(((object[])parameters[1])[0]);
            var posY = Convert.ToDouble(((object[])parameters[1])[1]);
            var name = parameters[2].ToString();

            var cageInstance = new Cage(id, posX, posY, name);

            _cages.Add(cageInstance);
        }

        public void CageOpenedEvent(object[] parameters)
        {
            if (!_settings.WispCage) return;

            var id = Convert.ToInt32(parameters[0]);

            if (!_cages.Any(c => c.Id == id)) return;

            RemoveCage(id);
        }

        public void RemoveCage(int id)
        {
            _cages.RemoveAll(c => c.Id == id);
        }

        public void RemoveNotInRange(double lpX, double lpY)
        {
            _cages.RemoveAll(c => CalculateDistance(lpX, lpY, c.PosX, c.PosY) > 80);
        }

        private double CalculateDistance(double lpX, double lpY, double posX, double posY)
        {
            var deltaX = lpX - posX;
            var deltaY = lpY - posY;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
