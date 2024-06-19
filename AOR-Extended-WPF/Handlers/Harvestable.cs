namespace AOR_Extended_WPF.Handlers
{
    public class Harvestable
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Tier { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; } = 0;
        public double HY { get; set; } = 0;
        public int Charges { get; set; }
        public int Size { get; set; }

        public Harvestable(int id, string type, int tier, double posX, double posY, int charges, int size)
        {
            Id = id;
            Type = type;
            Tier = tier;
            PosX = posX;
            PosY = posY;
            Charges = charges;
            Size = size;
        }

        public void SetCharges(int charges)
        {
            Charges = charges;
        }
    }
}
