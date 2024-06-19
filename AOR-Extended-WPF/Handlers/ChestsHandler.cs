using System;
using System.Collections.Generic;
using System.Linq;

namespace AOR_Extended_WPF.Handlers
{
    public class ChestsHandler
    {
        public List<Chest> ChestsList { get; private set; }

        public ChestsHandler()
        {
            ChestsList = new List<Chest>();
        }

        public void AddChest(int id, double posX, double posY, string name)
        {
            Chest chest = new Chest(id, posX, posY, name);
            if (!ChestsList.Any(c => c.Id == chest.Id))
            {
                ChestsList.Add(chest);
            }
        }

        public void RemoveChest(int id)
        {
            ChestsList = ChestsList.Where(c => c.Id != id).ToList();
        }

        public void AddChestEvent(List<object> Parameters)
        {
            int chestId = Convert.ToInt32(Parameters[0]);
            List<double> chestsPosition = ((IEnumerable<object>)Parameters[1]).Select(Convert.ToDouble).ToList();
            string chestName = Parameters[3].ToString();

            if (chestName.ToLower().Contains("mist"))
            {
                chestName = Parameters[4].ToString();
            }

            AddChest(chestId, chestsPosition[0], chestsPosition[1], chestName);
        }
    }
}
