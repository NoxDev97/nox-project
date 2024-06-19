namespace AOR_Extended_WPF.Handlers
{
    public class Fish
    {
        public int Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public string Type { get; set; }
        public int SizeSpawned { get; set; }
        public int SizeLeftToSpawn { get; set; }
        public int TotalSize => SizeSpawned + SizeLeftToSpawn;
        public double HX { get; set; } = 0;
        public double HY { get; set; } = 0;

        public Fish(int id, double posX, double posY, string type, int sizeSpawned = 0, int sizeLeftToSpawn = 0)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Type = type;
            SizeSpawned = sizeSpawned;
            SizeLeftToSpawn = sizeLeftToSpawn;
        }
    }
}
