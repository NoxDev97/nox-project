namespace AOR_Extended_WPF.Handlers
{
    public class Chest
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string ChestName { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public Chest(int id, double posX, double posY, string name)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            ChestName = name;
            HX = 0;
            HY = 0;
        }
    }
}
