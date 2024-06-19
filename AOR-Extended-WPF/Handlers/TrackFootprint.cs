namespace AOR_Extended_WPF.Handlers
{
    public class TrackFootprint
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string Name { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public TrackFootprint(int id, double posX, double posY, string name)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Name = name;
            HX = 0;
            HY = 0;
        }
    }
}
