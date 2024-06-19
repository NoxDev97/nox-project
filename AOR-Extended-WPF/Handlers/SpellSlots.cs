namespace AOR_Extended_WPF.Handlers
{
    public class SpellSlots
    {
        public int WeaponFirst { get; set; }
        public int WeaponSecond { get; set; }
        public int WeaponThird { get; set; }
        public int Helmet { get; set; }
        public int Chest { get; set; }
        public int Boots { get; set; }

        public SpellSlots()
        {
            WeaponFirst = 65535;
            WeaponSecond = 65535;
            WeaponThird = 65535;
            Helmet = 65535;
            Chest = 65535;
            Boots = 65535;
        }

        public SpellSlots(int weaponFirst, int weaponSecond, int weaponThird, int helmet, int chest, int boots)
        {
            WeaponFirst = weaponFirst;
            WeaponSecond = weaponSecond;
            WeaponThird = weaponThird;
            Helmet = helmet;
            Chest = chest;
            Boots = boots;
        }
    }
}
