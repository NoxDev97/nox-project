namespace AOR_Extended_WPF.MobInfo
{
    public class MobInfo
    {
        public string Tier { get; }
        public string Type { get; }
        public string Location { get; }

        public MobInfo(string tier, string type, string location)
        {
            Tier = tier;
            Type = type;
            Location = location;
        }
    }
}