using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
            var value = Convert.ToString(Properties.Settings.Default[key]);
            return value == "true";
        }

        public void Update()
        {
            ShowMapBackground = ReturnLocalBool("settingShowMap");

            // Players
            SettingOnOff = ReturnLocalBool("settingOnOff");
            SettingNickname = ReturnLocalBool("settingNickname");
            SettingHealth = ReturnLocalBool("settingHealth");
            SettingMounted = ReturnLocalBool("settingMounted");
            SettingItems = ReturnLocalBool("settingItems");
            SettingItemsDev = ReturnLocalBool("settingItemsDev");
            SettingSpells = ReturnLocalBool("settingSpells");
            SettingSpellsDev = ReturnLocalBool("settingSpellsDev");
            SettingDistance = ReturnLocalBool("settingDistance");
            SettingGuild = ReturnLocalBool("settingGuild");
            SettingSound = ReturnLocalBool("settingSound");

            // Static Resources
            HarvestingStaticFiber = DeserializeHarvestingDict("settingStaticFiberEnchants");
            HarvestingStaticHide = DeserializeHarvestingDict("settingStaticHideEnchants");
            HarvestingStaticOre = DeserializeHarvestingDict("settingStaticOreEnchants");
            HarvestingStaticWood = DeserializeHarvestingDict("settingStaticWoodEnchants");
            HarvestingStaticRock = DeserializeHarvestingDict("settingStaticRockEnchants");

            // Living Resources
            HarvestingLivingFiber = DeserializeHarvestingDict("settingLivingFiberEnchants");
            HarvestingLivingHide = DeserializeHarvestingDict("settingLivingHideEnchants");
            HarvestingLivingOre = DeserializeHarvestingDict("settingLivingOreEnchants");
            HarvestingLivingWood = DeserializeHarvestingDict("settingLivingWoodEnchants");
            HarvestingLivingRock = DeserializeHarvestingDict("settingLivingRockEnchants");

            LivingResourcesHP = ReturnLocalBool("settingLivingResourcesHP");
            LivingResourcesID = ReturnLocalBool("settingLivingResourcesID");
            ResourceSize = ReturnLocalBool("settingRawSize");
            ShowFish = ReturnLocalBool("settingFishing");

            // Enemies
            EnemyLevels[0] = ReturnLocalBool("settingNormalEnemy");
            EnemyLevels[1] = ReturnLocalBool("settingMediumEnemy");
            EnemyLevels[2] = ReturnLocalBool("settingEnchantedEnemy");
            EnemyLevels[3] = ReturnLocalBool("settingMiniBossEnemy");
            EnemyLevels[4] = ReturnLocalBool("settingBossEnemy");

            AvaloneDrones = ReturnLocalBool("settingAvaloneDrones");
            ShowUnmanagedEnemies = ReturnLocalBool("settingShowUnmanagedEnemies");
            ShowEventEnemies = ReturnLocalBool("settingShowEventEnemies");

            EnemiesHP = ReturnLocalBool("settingEnemiesHP");
            EnemiesID = ReturnLocalBool("settingEnemiesID");

            // Mists
            BossCrystalSpider = ReturnLocalBool("settingBossCrystalSpider");
            BossFairyDragon = ReturnLocalBool("settingBossFairyDragon");
            BossVeilWeaver = ReturnLocalBool("settingBossVeilWeaver");
            BossGriffin = ReturnLocalBool("settingBossGriffin");

            // Chests
            ChestGreen = ReturnLocalBool("settingChestGreen");
            ChestBlue = ReturnLocalBool("settingChestBlue");
            ChestPurple = ReturnLocalBool("settingChestPurple");
            ChestYellow = ReturnLocalBool("settingChestYellow");

            // Mists
            MistSolo = ReturnLocalBool("settingMistSolo");
            MistDuo = ReturnLocalBool("settingMistDuo");
            WispCage = ReturnLocalBool("settingCage");

            MistEnchants[0] = ReturnLocalBool("settingMistE0");
            MistEnchants[1] = ReturnLocalBool("settingMistE1");
            MistEnchants[2] = ReturnLocalBool("settingMistE2");
            MistEnchants[3] = ReturnLocalBool("settingMistE3");
            MistEnchants[4] = ReturnLocalBool("settingMistE4");

            // Dungeons
            DungeonEnchants[0] = ReturnLocalBool("settingDungeonE0");
            DungeonEnchants[1] = ReturnLocalBool("settingDungeonE1");
            DungeonEnchants[2] = ReturnLocalBool("settingDungeonE2");
            DungeonEnchants[3] = ReturnLocalBool("settingDungeonE3");
            DungeonEnchants[4] = ReturnLocalBool("settingDungeonE4");

            DungeonSolo = ReturnLocalBool("settingDungeonSolo");
            DungeonGroup = ReturnLocalBool("settingDungeonDuo");
            DungeonCorrupted = ReturnLocalBool("settingDungeonCorrupted");
            DungeonHellgate = ReturnLocalBool("settingDungeonHellgate");

            // FootTracks
            SettingFootTracksSolo = ReturnLocalBool("settingFootTracksSolo");
            SettingFootTracksGroup = ReturnLocalBool("settingFootTracksGroup");

            IgnoreList = DeserializeIgnoreList("ignoreList");
        }

        private Dictionary<string, List<bool>> DeserializeHarvestingDict(string key)
        {
            var value = Convert.ToString(Properties.Settings.Default[key]);
            return string.IsNullOrEmpty(value) ? CreateHarvestingDict() : Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<bool>>>(value);
        }

        private List<string> DeserializeIgnoreList(string key)
        {
            var value = Convert.ToString(Properties.Settings.Default[key]);
            return string.IsNullOrEmpty(value) ? new List<string>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(value);
        }
    }
}
