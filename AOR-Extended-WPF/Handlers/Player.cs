using System.Collections.Generic;

namespace AOR_Extended_WPF.Handlers
{
    public class Player
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double OldPosX { get; set; }
        public double OldPosY { get; set; }
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string GuildName { get; set; }
        public string Alliance { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public double CurrentHealth { get; set; }
        public double InitialHealth { get; set; }
        public List<string> Items { get; set; }
        public int FlagId { get; set; }
        public bool Mounted { get; set; }
        public SpellSlots Spells { get; set; }

        public Player() { }

        public Player(double posX, double posY, int id, string nickname, string guildName, double currentHealth, double initialHealth, List<string> items, int flagId, SpellSlots spells, string alliance)
        {
            PosX = posX;
            PosY = posY;
            OldPosX = posX;
            OldPosY = posY;
            Id = id;
            Nickname = nickname;
            GuildName = guildName;
            Alliance = alliance;
            HX = 0;
            HY = 0;
            CurrentHealth = currentHealth;
            InitialHealth = initialHealth;
            Items = items;
            FlagId = flagId;
            Mounted = false;
            Spells = spells ?? new SpellSlots();
        }

        public void SetMounted(bool mounted)
        {
            Mounted = mounted;
        }
    }
}
