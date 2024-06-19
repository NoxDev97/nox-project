using System;
using System.Collections.Generic;
using System.Linq;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Handlers
{
    public class DungeonsHandler
    {
        public List<Dungeon> DungeonList { get; private set; }
        private Settings settings;

        public DungeonsHandler(Settings settings)
        {
            DungeonList = new List<Dungeon>();
            this.settings = settings;
        }

        public void DungeonEvent(List<object> parameters)
        {
            int id = Convert.ToInt32(parameters[0]);
            List<double> position = ((IEnumerable<object>)parameters[1]).Select(Convert.ToDouble).ToList();
            string name = parameters[3].ToString();
            int enchant = Convert.ToInt32(parameters[6]);

            AddDungeon(id, position[0], position[1], name, enchant);
        }

        public void AddDungeon(int id, double posX, double posY, string name, int enchant)
        {
            if (DungeonList.Any(d => d.Id == id)) return;

            string lowerCaseName = name.ToLower();
            DungeonType? dungeonType = null;

            if (lowerCaseName.Contains("corrupted"))
            {
                if (!settings.DungeonCorrupted) return;
                dungeonType = DungeonType.Corrupted;
            }
            else if (lowerCaseName.Contains("solo"))
            {
                if (!settings.DungeonSolo || !settings.DungeonEnchants[enchant]) return;
                dungeonType = DungeonType.Solo;
            }
            else if (lowerCaseName.Contains("hellgate"))
            {
                if (!settings.DungeonHellgate) return;
                dungeonType = DungeonType.Hellgate;
            }
            else
            {
                if (!settings.DungeonGroup || !settings.DungeonEnchants[enchant]) return;
                dungeonType = DungeonType.Group;
            }

            if (dungeonType.HasValue)
            {
                Dungeon dungeon = new Dungeon(id, posX, posY, name, dungeonType.Value, enchant);
                DungeonList.Add(dungeon);
            }
        }

        public void RemoveDungeon(int id)
        {
            DungeonList = DungeonList.Where(d => d.Id != id).ToList();
        }
    }
}
