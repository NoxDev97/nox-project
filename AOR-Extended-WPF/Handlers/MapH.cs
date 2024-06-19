namespace AOR_Extended_WPF.Handlers
{
    public class MapH
    {
        public int Id { get; private set; }
        public double HX { get; set; }
        public double HY { get; set; }

        public MapH(int id)
        {
            Id = id;
            HX = 0;
            HY = 0;
        }
    }
}