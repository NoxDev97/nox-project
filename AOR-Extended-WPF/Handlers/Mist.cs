namespace AOR_Extended_WPF.Handlers
{
    public class Mist
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string Name { get; set; }
        public int Enchant { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public int Type { get; set; }

        public Mist(int id, double posX, double posY, string name, int enchant)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Name = name;
            Enchant = enchant;
            HX = 0;
            HY = 0;

            Type = name.ToLower().Contains("solo") ? 0 : 1;
        }
    }
}
