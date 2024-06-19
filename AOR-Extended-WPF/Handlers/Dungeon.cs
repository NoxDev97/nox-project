namespace AOR_Extended_WPF.Handlers
{
    public class Dungeon
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string Name { get; set; }
        public int Enchant { get; set; }
        public DungeonType Type { get; set; }
        public string DrawName { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public Dungeon(int id, double posX, double posY, string name, DungeonType type, int enchant)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Name = name;
            Type = type;
            Enchant = enchant;
            HX = 0;
            HY = 0;

            SetDrawNameByType();
        }

        private void SetDrawNameByType()
        {
            switch (Type)
            {
                case DungeonType.Solo:
                    DrawName = "dungeon_" + Enchant;
                    break;
                case DungeonType.Group:
                    DrawName = "group_" + Enchant;
                    break;
                case DungeonType.Corrupted:
                    DrawName = "corrupt";
                    break;
                case DungeonType.Hellgate:
                    DrawName = "hellgate";
                    break;
            }
        }
    }
}
