using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SpellsNamespace;

namespace AOR_Extended_WPF.Utils
{
    public class Settings
    {
        // Initialization
        public int MinHP { get; set; }
        public Dictionary<string, BitmapImage> Images { get; set; }
        public Dictionary<string, BitmapImage> ItemImages { get; set; }
        public Dictionary<string, BitmapImage> MapImages { get; set; }
        public Dictionary<string, BitmapImage> FlagImages { get; set; }
        public Dictionary<string, BitmapImage> SpellImages { get; set; }

        // Maps
        public bool ShowMapBackground { get; set; }

        // Players
        public bool SettingOnOff { get; set; }
        public bool SettingNickname { get; set; }
        public bool SettingHealth { get; set; }
        public bool SettingMounted { get; set; }
        public bool SettingSpells { get; set; }
        public bool SettingSpellsDev { get; set; }
        public bool SettingItems { get; set; }
        public bool SettingItemsDev { get; set; }
        public bool SettingDistance { get; set; }
        public bool SettingGuild { get; set; }
        public double Scale { get; set; }
        public bool SettingSound { get; set; }

        public List<string> IgnoreList { get; set; }

        // Static Resources
        public Dictionary<string, List<bool>> HarvestingStaticFiber { get; set; }
        public Dictionary<string, List<bool>> HarvestingStaticWood { get; set; }
        public Dictionary<string, List<bool>> HarvestingStaticHide { get; set; }
        public Dictionary<string, List<bool>> HarvestingStaticOre { get; set; }
        public Dictionary<string, List<bool>> HarvestingStaticRock { get; set; }

        // Living Resources
        public Dictionary<string, List<bool>> HarvestingLivingFiber { get; set; }
        public Dictionary<string, List<bool>> HarvestingLivingWood { get; set; }
        public Dictionary<string, List<bool>> HarvestingLivingHide { get; set; }
        public Dictionary<string, List<bool>> HarvestingLivingOre { get; set; }
        public Dictionary<string, List<bool>> HarvestingLivingRock { get; set; }

        public bool LivingResourcesHP { get; set; }
        public bool LivingResourcesID { get; set; }
        public bool ResourceSize { get; set; }
        public bool ShowFish { get; set; }

        // Dungeons
        public bool MistSolo { get; set; }
        public bool MistDuo { get; set; }
        public List<bool> MistEnchants { get; set; }
        public bool WispCage { get; set; }
        public bool DungeonSolo { get; set; }
        public bool DungeonGroup { get; set; }
        public List<bool> DungeonEnchants { get; set; }
        public bool DungeonCorrupted { get; set; }
        public bool DungeonHellgate { get; set; }

        // Enemies
        public List<bool> EnemyLevels { get; set; }
        public bool AvaloneDrones { get; set; }
        public bool ShowUnmanagedEnemies { get; set; }
        public bool ShowEventEnemies { get; set; }
        public bool BossCrystalSpider { get; set; }
        public bool BossFairyDragon { get; set; }
        public bool BossVeilWeaver { get; set; }
        public bool BossGriffin { get; set; }
        public bool EnemiesHP { get; set; }
        public bool EnemiesID { get; set; }

        // Chests
        public bool ChestGreen { get; set; }
        public bool ChestBlue { get; set; }
        public bool ChestPurple { get; set; }
        public bool ChestYellow { get; set; }

        // FootTracks
        public bool SettingFootTracksSolo { get; set; }
        public bool SettingFootTracksGroup { get; set; }

        // Adicionar a propriedade SpellsInfo
        public Dictionary<int, Spell> SpellsInfo { get; private set; }

        public Settings()
        {
            // Initialization
            Images = new Dictionary<string, BitmapImage>();
            ItemImages = new Dictionary<string, BitmapImage>();
            MapImages = new Dictionary<string, BitmapImage>();
            FlagImages = new Dictionary<string, BitmapImage>();
            SpellImages = new Dictionary<string, BitmapImage>();

            // Players
            Scale = 4.0;
            IgnoreList = new List<string>();

            // Static Resources
            HarvestingStaticFiber = CreateHarvestingDict();
            HarvestingStaticWood = CreateHarvestingDict();
            HarvestingStaticHide = CreateHarvestingDict();
            HarvestingStaticOre = CreateHarvestingDict();
            HarvestingStaticRock = CreateHarvestingDict();

            // Living Resources
            HarvestingLivingFiber = CreateHarvestingDict();
            HarvestingLivingWood = CreateHarvestingDict();
            HarvestingLivingHide = CreateHarvestingDict();
            HarvestingLivingOre = CreateHarvestingDict();
            HarvestingLivingRock = CreateHarvestingDict();
            MistEnchants = new List<bool> { false, false, false, false, false };
            DungeonEnchants = new List<bool> { false, false, false, false, false };
            EnemyLevels = new List<bool> { false, false, false, false, false };

            // Inicialização do SpellsInfo
            var spellsInfo = new SpellsInfo();
            spellsInfo.InitSpells();
            SpellsInfo = spellsInfo.GetSpellList();

            Update();
        }

        private Dictionary<string, List<bool>> CreateHarvestingDict()
        {
            return new Dictionary<string, List<bool>>
            {
                { "e0", new List<bool> { false, false, false, false, false, false, false, false } },
                { "e1", new List<bool> { false, false, false, false, false, false, false, false } },
                { "e2", new List<bool> { false, false, false, false, false, false, false, false } },
                { "e3", new List<bool> { false, false, false, false, false, false, false, false } },
                { "e4", new List<bool> { false, false, false, false, false, false, false, false } }
            };
        }

        public BitmapImage GetPreloadedImage(string path, string container)
        {
            switch (container)
            {
                case "Resources":
                    return Images.ContainsKey(path) ? Images[path] : null;
                case "Maps":
                    return MapImages.ContainsKey(path) ? MapImages[path] : null;
                case "Items":
                    return ItemImages.ContainsKey(path) ? ItemImages[path] : null;
                case "Spells":
                    return SpellImages.ContainsKey(path) ? SpellImages[path] : null;
                case "Flags":
                    return FlagImages.ContainsKey(path) ? FlagImages[path] : null;
                default:
                    return null;
            }
        }

        public async Task PreloadImageAndAddToList(string path, string container)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Image not found: {path}");
                return;
            }

            BitmapImage bitmap = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));

            switch (container)
            {
                case "Resources":
                    if (!Images.ContainsKey(path)) Images.Add(path, bitmap);
                    break;
                case "Maps":
                    if (!MapImages.ContainsKey(path)) MapImages.Add(path, bitmap);
                    break;
                case "Items":
                    if (!ItemImages.ContainsKey(path)) ItemImages.Add(path, bitmap);
                    break;
                case "Spells":
                    if (!SpellImages.ContainsKey(path)) SpellImages.Add(path, bitmap);
                    break;
                case "Flags":
                    if (!FlagImages.ContainsKey(path)) FlagImages.Add(path, bitmap);
                    break;
                default:
                    throw new ArgumentException("Invalid container type");
            }
        }

        public void ClearPreloadedImages(string container)
        {
            switch (container)
            {
                case "Resources":
                    Images.Clear();
                    break;
                case "Maps":
                    MapImages.Clear();
                    break;
                case "Items":
                    ItemImages.Clear();
                    break;
                case "Spells":
                    SpellImages.Clear();
                    break;
                case "_ALL_":
                    Images.Clear();
                    MapImages.Clear();
                    ItemImages.Clear();
                    SpellImages.Clear();
                    break;
            }
        }

        public bool ReturnLocalBool(string key)
        {
            if (Properties.Settings.Default[key] is bool boolValue)
            {
                return boolValue;
            }

            var value = Convert.ToString(Properties.Settings.Default[key]);
            return value?.ToLower() == "true";
        }

        public void Update()
        {
            Console.WriteLine("Updating settings...");

            ShowMapBackground = ReturnLocalBool("settingShowMap");
            Console.WriteLine($"ShowMapBackground: {ShowMapBackground}");

            // Players
            SettingOnOff = ReturnLocalBool("settingOnOff");
            Console.WriteLine($"SettingOnOff: {SettingOnOff}");
            SettingNickname = ReturnLocalBool("settingNickname");
            Console.WriteLine($"SettingNickname: {SettingNickname}");
            SettingHealth = ReturnLocalBool("settingHealth");
            Console.WriteLine($"SettingHealth: {SettingHealth}");
            SettingMounted = ReturnLocalBool("settingMounted");
            Console.WriteLine($"SettingMounted: {SettingMounted}");
            SettingSpells = ReturnLocalBool("settingSpells");
            Console.WriteLine($"SettingSpells: {SettingSpells}");
            SettingSpellsDev = ReturnLocalBool("settingSpellsDev");
            Console.WriteLine($"SettingSpellsDev: {SettingSpellsDev}");
            SettingItems = ReturnLocalBool("settingItems");
            Console.WriteLine($"SettingItems: {SettingItems}");
            SettingItemsDev = ReturnLocalBool("settingItemsDev");
            Console.WriteLine($"SettingItemsDev: {SettingItemsDev}");
            SettingDistance = ReturnLocalBool("settingDistance");
            Console.WriteLine($"SettingDistance: {SettingDistance}");
            SettingGuild = ReturnLocalBool("settingGuild");
            Console.WriteLine($"SettingGuild: {SettingGuild}");

            // Resources
            LivingResourcesHP = ReturnLocalBool("settingLivingResourcesHP");
            Console.WriteLine($"LivingResourcesHP: {LivingResourcesHP}");
            LivingResourcesID = ReturnLocalBool("settingLivingResourcesID");
            Console.WriteLine($"LivingResourcesID: {LivingResourcesID}");
            ResourceSize = ReturnLocalBool("settingResourceSize");
            Console.WriteLine($"ResourceSize: {ResourceSize}");
            ShowFish = ReturnLocalBool("settingShowFish");
            Console.WriteLine($"ShowFish: {ShowFish}");

            // Dungeons
            MistSolo = ReturnLocalBool("settingMistSolo");
            Console.WriteLine($"MistSolo: {MistSolo}");
            MistDuo = ReturnLocalBool("settingMistDuo");
            Console.WriteLine($"MistDuo: {MistDuo}");
            WispCage = ReturnLocalBool("settingWispCage");
            Console.WriteLine($"WispCage: {WispCage}");
            DungeonSolo = ReturnLocalBool("settingDungeonSolo");
            Console.WriteLine($"DungeonSolo: {DungeonSolo}");
            DungeonGroup = ReturnLocalBool("settingDungeonGroup");
            Console.WriteLine($"DungeonGroup: {DungeonGroup}");
            DungeonCorrupted = ReturnLocalBool("settingDungeonCorrupted");
            Console.WriteLine($"DungeonCorrupted: {DungeonCorrupted}");
            DungeonHellgate = ReturnLocalBool("settingDungeonHellgate");
            Console.WriteLine($"DungeonHellgate: {DungeonHellgate}");

            // Enemies
            ShowUnmanagedEnemies = ReturnLocalBool("settingShowUnmanagedEnemies");
            Console.WriteLine($"ShowUnmanagedEnemies: {ShowUnmanagedEnemies}");
            ShowEventEnemies = ReturnLocalBool("settingShowEventEnemies");
            Console.WriteLine($"ShowEventEnemies: {ShowEventEnemies}");
            BossCrystalSpider = ReturnLocalBool("settingBossCrystalSpider");
            Console.WriteLine($"BossCrystalSpider: {BossCrystalSpider}");
            BossFairyDragon = ReturnLocalBool("settingBossFairyDragon");
            Console.WriteLine($"BossFairyDragon: {BossFairyDragon}");
            BossVeilWeaver = ReturnLocalBool("settingBossVeilWeaver");
            Console.WriteLine($"BossVeilWeaver: {BossVeilWeaver}");
            BossGriffin = ReturnLocalBool("settingBossGriffin");
            Console.WriteLine($"BossGriffin: {BossGriffin}");
            EnemiesHP = ReturnLocalBool("settingEnemiesHP");
            Console.WriteLine($"EnemiesHP: {EnemiesHP}");
            EnemiesID = ReturnLocalBool("settingEnemiesID");
            Console.WriteLine($"EnemiesID: {EnemiesID}");

            // Chests
            ChestGreen = ReturnLocalBool("settingChestGreen");
            Console.WriteLine($"ChestGreen: {ChestGreen}");
            ChestBlue = ReturnLocalBool("settingChestBlue");
            Console.WriteLine($"ChestBlue: {ChestBlue}");
            ChestPurple = ReturnLocalBool("settingChestPurple");
            Console.WriteLine($"ChestPurple: {ChestPurple}");
            ChestYellow = ReturnLocalBool("settingChestYellow");
            Console.WriteLine($"ChestYellow: {ChestYellow}");

            // FootTracks
            SettingFootTracksSolo = ReturnLocalBool("settingFootTracksSolo");
            Console.WriteLine($"SettingFootTracksSolo: {SettingFootTracksSolo}");
            SettingFootTracksGroup = ReturnLocalBool("settingFootTracksGroup");
            Console.WriteLine($"SettingFootTracksGroup: {SettingFootTracksGroup}");
        }
    }
}
