namespace AOR_Extended_WPF.Handlers
{
    public class Mob
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double Health { get; set; }
        public int EnchantmentLevel { get; set; }
        public int Rarity { get; set; }
        public int Tier { get; set; }
        public EnemyType Type { get; set; }
        public string Name { get; set; }
        public double Exp { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public Mob(int id, int typeId, double posX, double posY, double health, int enchantmentLevel, int rarity)
        {
            Id = id;
            TypeId = typeId;
            PosX = posX;
            PosY = posY;
            Health = health;
            EnchantmentLevel = enchantmentLevel;
            Rarity = rarity;
            HX = 0;
            HY = 0;
        }
    }
}
