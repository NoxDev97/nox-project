using System.Collections.Generic;

namespace AOR_Extended_WPF.MobInfo
{
    public static class Mobs
    {
        public static readonly Dictionary<int, MobInfo> mobs = new Dictionary<int, MobInfo>
        {
            // Steppe Biome
            { 350, new MobInfo("1", "1", "hide") }, // Marmot
            { 351, new MobInfo("2", "1", "hide") }, // Impala
            { 352, new MobInfo("3", "1", "hide") }, // Moabird
            { 353, new MobInfo("4", "1", "hide") }, // Giant Stag
            { 354, new MobInfo("5", "1", "hide") }, // Terrorbird
            { 355, new MobInfo("6", "1", "hide") }, // Hyena
            { 356, new MobInfo("7", "1", "hide") }, // Rhino
            { 358, new MobInfo("8", "1", "hide") }, // Mammoth 
            { 359, new MobInfo("8", "1", "hide") }, // Ancient Mammoth 
            // Steppe Biome treasure
            { 360, new MobInfo("4", "1", "hide") }, // Rare Giant Stag 
            { 361, new MobInfo("5", "1", "hide") },
            { 362, new MobInfo("6", "1", "hide") },
            { 363, new MobInfo("7", "1", "hide") },
            { 364, new MobInfo("8", "1", "hide") }, // Rare Ancient Mammoth
            // Cougars
            { 439, new MobInfo("3", "1", "hide") }, // Cougar
            { 440, new MobInfo("5", "1", "hide") }, // Cougar
            { 441, new MobInfo("7", "1", "hide") }, // Cougar
            // Highland Biome
            { 372, new MobInfo("1", "1", "hide") }, // Rabbit
            { 366, new MobInfo("1", "1", "hide") }, // Hill Marmot
            // Forest Biome
            { 322, new MobInfo("1", "1", "hide") }, // Rabbit
            { 323, new MobInfo("2", "1", "hide") }, // Fox
            { 324, new MobInfo("2", "1", "hide") }, // Fox tutorial
            { 325, new MobInfo("3", "1", "hide") }, // Wolf
            { 326, new MobInfo("4", "1", "hide") }, // Boar
            { 327, new MobInfo("5", "1", "hide") }, // Bear
            { 328, new MobInfo("6", "1", "hide") }, // Direwolf
            { 329, new MobInfo("6", "1", "hide") }, // Moose
            { 330, new MobInfo("7", "1", "hide") }, // Feral Boar
            { 331, new MobInfo("7", "1", "hide") }, // Direboar
            { 332, new MobInfo("8", "1", "hide") }, // Feral Bear
            { 333, new MobInfo("8", "1", "hide") }, // Direbear
            // Forest Biome treasure
            { 334, new MobInfo("4", "1", "hide") },
            { 335, new MobInfo("5", "1", "hide") },
            { 336, new MobInfo("6", "1", "hide") },
            { 337, new MobInfo("7", "1", "hide") }, // Rare Direboar
            { 338, new MobInfo("8", "1", "hide") }, // Rare Direbear
            // Swamp Biome
            { 339, new MobInfo("1", "1", "hide") }, // Toad
            { 340, new MobInfo("2", "1", "hide") }, // Snake
            { 341, new MobInfo("3", "1", "hide") }, // Giant Toad
            { 342, new MobInfo("4", "1", "hide") }, // Monitor Lizard
            { 343, new MobInfo("5", "1", "hide") }, // Giant Snake
            { 344, new MobInfo("6", "1", "hide") }, // Swamp Dragon
            { 345, new MobInfo("7", "1", "hide") },
            { 346, new MobInfo("8", "1", "hide") },
            // Mountain Biome
            { 365, new MobInfo("1", "1", "hide") }, // Snow Rabbit 
            // Mists
            { 294, new MobInfo("1", "1", "hide") }, // Wolpertinger
            { 295, new MobInfo("2", "1", "hide") }, // Fey Fox
            { 296, new MobInfo("3", "1", "hide") }, // Foglands Doe
            { 297, new MobInfo("4", "1", "hide") }, // Foglands Hart
            { 298, new MobInfo("5", "1", "hide") }, // Great Mystic Owl
            { 299, new MobInfo("6", "1", "hide") }, // Feral Wolfhound
            { 300, new MobInfo("7", "1", "hide") }, // Misthide Mauler
            { 301, new MobInfo("8", "1", "hide") }, // Dragonhawk
            // Treasure Mists
            { 302, new MobInfo("4", "1", "hide") },
            { 303, new MobInfo("5", "1", "hide") },
            { 304, new MobInfo("6", "1", "hide") },
            { 305, new MobInfo("7", "1", "hide") },
            { 306, new MobInfo("8", "1", "hide") },
            // Cougars
            { 459, new MobInfo("6", "1", "hide") }, // Mistcougar
            { 460, new MobInfo("7", "1", "hide") }, // Large Mistcougar
            { 461, new MobInfo("8", "1", "hide") }, // Alpha Mistcougar
            // Region Roads
            // Roads - Normal
            { 457, new MobInfo("4", "1", "hide") },
            // Roads Veteran - Old
            { 477, new MobInfo("4", "0", "Logs") }, // Old Pine Spirit
            { 478, new MobInfo("5", "0", "Logs") }, // Old Cedar Spirit
            { 479, new MobInfo("6", "0", "Logs") }, // Old Bloodoak Spirit
            { 480, new MobInfo("7", "0", "Logs") }, // Old Ashenbark Spirit
            { 481, new MobInfo("8", "0", "Logs") }, // Old Whitewood Spirit
            // Mists - T5/T6
            { 532, new MobInfo("3", "0", "Logs") }, // Forest Spirit
            { 533, new MobInfo("4", "0", "Logs") }, // Pine Spirit
            { 534, new MobInfo("5", "0", "Logs") }, // Cedar Spirit
            { 535, new MobInfo("6", "0", "Logs") }, // Bloodoak Spirit
            // Mists - T7
            { 556, new MobInfo("3", "0", "Logs") }, // Forest Spirit
            { 557, new MobInfo("4", "0", "Logs") }, // Forest Spirit
            { 558, new MobInfo("5", "0", "Logs") }, // Cedar Spirit
            { 559, new MobInfo("6", "0", "Logs") }, // Bloodoak Spirit
            { 560, new MobInfo("7", "0", "Logs") }, // Ashenbark Spirit
            // Mists - T8
            { 580, new MobInfo("3", "0", "Logs") }, // Forest Spirit
            { 581, new MobInfo("4", "0", "Logs") }, // Pine Spirit
            { 582, new MobInfo("5", "0", "Logs") }, // Cedar Spirit
            { 583, new MobInfo("6", "0", "Logs") }, // Bloodoak Spirit
            { 584, new MobInfo("7", "0", "Logs") }, // Ashenbark Spirit
            { 585, new MobInfo("8", "0", "Logs") }, // Whitewood Spirit
            { 659, new MobInfo("8", "6", "GUARDIANFORESTSPIRTIT3") }, // Old Whitewood Aspect
            // Region Rock
            // Highland
            // Region Roads
            { 453, new MobInfo("3", "0", "rock") }, // Rock Elemental
            { 454, new MobInfo("5", "0", "rock") }, // Mature Rock Elemental
            { 455, new MobInfo("6", "0", "rock") }, // Mature Rock Elemental
            { 456, new MobInfo("7", "0", "rock") }, // Elder Rock Elemental
            // Roads - NORMAL
            { 487, new MobInfo("4", "0", "rock") }, // Travertine Elemental
            { 488, new MobInfo("5", "0", "rock") }, // Granite Elemental
            { 489, new MobInfo("6", "0", "rock") }, // Slate Elemental
            // Veteran Roads - OLD
            { 492, new MobInfo("4", "0", "rock") }, // Old Travertine Elemental
            { 493, new MobInfo("5", "0", "rock") }, // Old Granite Elemental
            { 494, new MobInfo("6", "0", "rock") }, // Old Slate Elemental
            // Region Mists
            // Mists - T5/T6
            { 538, new MobInfo("3", "0", "rock") }, // Rock Elemental
            { 539, new MobInfo("4", "0", "rock") }, // Travertine Elemental
            { 540, new MobInfo("5", "0", "rock") }, // Granite Elemental
            { 541, new MobInfo("6", "0", "rock") }, // Slate Elemental
            // Mists - T7
            { 562, new MobInfo("3", "0", "rock") }, // Rock Elemental
            { 563, new MobInfo("4", "0", "rock") }, // Travertine Elemental
            { 564, new MobInfo("5", "0", "rock") }, // Granite Elemental
            { 566, new MobInfo("7", "0", "rock") }, // Basalt Elemental
            // Mists - T8
            { 586, new MobInfo("3", "0", "rock") }, // Rock Elemental
            { 587, new MobInfo("4", "0", "rock") }, // Travertine Elemental
            { 588, new MobInfo("5", "0", "rock") }, // Granite Elemental
            { 589, new MobInfo("6", "0", "rock") }, // Slate Elemental
            { 590, new MobInfo("7", "0", "rock") }, // Basalt Elemental
            { 591, new MobInfo("8", "0", "rock") }, // Marble Elemental
            { 615, new MobInfo("6", "0", "GUARDIANROCKGIANT1") }, // Rock Giant
            // Region Ore
            // Mountain
            { 443, new MobInfo("3", "0", "ore") }, // Ore Elemental
            { 444, new MobInfo("5", "0", "ore") }, // Mature Ore Elemental
            { 446, new MobInfo("7", "0", "ore") }, // Elder Ore Elemental
            // Region Roads
            // Roads - NORMAL
            { 502, new MobInfo("4", "0", "ore") }, // Iron Elemental
            { 503, new MobInfo("5", "0", "ore") }, // Titanium Elemental
            { 504, new MobInfo("6", "0", "ore") }, // Runite Elemental
            { 505, new MobInfo("7", "0", "ore") }, // Meteorite Elemental
            // Veteran Roads - OLD
            { 508, new MobInfo("5", "0", "ore") }, // Old Titanium Elemental 
            { 509, new MobInfo("6", "0", "ore") }, // Old Runite Elemental
            { 510, new MobInfo("7", "0", "ore") }, // Old Meteorite Elemental
            { 511, new MobInfo("8", "0", "ore") }, // Old Adamantium Elemental
            // Mists Common - Uncommon
            { 544, new MobInfo("3", "0", "ore") }, // Ore Elemental
            { 545, new MobInfo("4", "0", "ore") }, // Iron Elemental
            { 546, new MobInfo("5", "0", "ore") }, // Titanium Elemental
            { 547, new MobInfo("6", "0", "ore") }, // Runite Elemental
            { 548, new MobInfo("7", "0", "ore") }, // Meteorite Elemental
            { 549, new MobInfo("8", "0", "ore") }, // Adamantium Elemental
            // Mists - T7/T8
            { 568, new MobInfo("3", "0", "ore") }, // Ore Elemental
            { 569, new MobInfo("4", "0", "ore") }, // Iron Elemental
            { 570, new MobInfo("5", "0", "ore") }, // Titanium Elemental
            { 571, new MobInfo("6", "0", "ore") }, // Runite Elemental
            { 572, new MobInfo("7", "0", "ore") }, // Meteorite Elemental
            { 573, new MobInfo("8", "0", "ore") }, // Adamantium Elemental
            // Mists - T8
            { 592, new MobInfo("3", "0", "ore") }, // Ore Elemental
            { 593, new MobInfo("4", "0", "ore") }, // Iron Elemental
            { 594, new MobInfo("5", "0", "ore") }, // Titanium Elemental
            { 595, new MobInfo("6", "0", "ore") }, // Runite Elemental
            { 596, new MobInfo("7", "0", "ore") }, // Meteorite Elemental
            { 597, new MobInfo("8", "0", "ore") }, // Adamantium Elemental
             // Pyromaniac
            { 970, new MobInfo("4", "6", "Enemy5") },
            { 971, new MobInfo("5", "6", "Enemy5") },
            { 972, new MobInfo("6", "6", "Enemy5") },
            { 973, new MobInfo("7", "6", "Enemy5") },
            { 974, new MobInfo("8", "6", "Enemy5") }, 
            // The Undead
            // Brittle Revenant
            { 1431, new MobInfo("4", "2", "Enemy1") },
            { 1432, new MobInfo("5", "2", "Enemy1") },
            { 1433, new MobInfo("6", "2", "Enemy1") },
            { 1434, new MobInfo("7", "2", "Enemy1") },
            { 1435, new MobInfo("8", "2", "Enemy1") }, 
            // Brittle Revenant - Summoned
            { 1784, new MobInfo("5", "2", "Enemy1") },
            { 1785, new MobInfo("6", "2", "Enemy1") },
            { 1786, new MobInfo("7", "2", "Enemy1") },
            { 1787, new MobInfo("8", "2", "Enemy1") }, 
            // Ghoul
            { 1449, new MobInfo("4", "2", "Enemy1") },
            { 1450, new MobInfo("5", "2", "Enemy1") },
            { 1451, new MobInfo("6", "2", "Enemy1") },
            { 1452, new MobInfo("7", "2", "Enemy1") },
            { 1453, new MobInfo("8", "2", "Enemy1") }, 
            // Feeble Frostweaver
            { 1440, new MobInfo("4", "2", "Enemy1") },
            { 1441, new MobInfo("5", "2", "Enemy1") },
            { 1442, new MobInfo("6", "2", "Enemy1") },
            { 1443, new MobInfo("7", "2", "Enemy1") },
            { 1444, new MobInfo("8", "2", "Enemy1") }, 
            // Revenant
            { 1458, new MobInfo("4", "3", "Enemy2") },
            { 1459, new MobInfo("5", "3", "Enemy2") },
            { 1460, new MobInfo("6", "3", "Enemy2") },
            { 1461, new MobInfo("7", "3", "Enemy2") },
            { 1462, new MobInfo("8", "3", "Enemy2") }, 
            // Frostweaver
            { 1521, new MobInfo("4", "3", "Enemy2") },
            { 1522, new MobInfo("5", "3", "Enemy2") },
            { 1523, new MobInfo("6", "3", "Enemy2") },
            { 1524, new MobInfo("7", "3", "Enemy2") },
            { 1525, new MobInfo("8", "3", "Enemy2") }, 
            // Bone Archer
            { 1485, new MobInfo("4", "3", "Enemy2") },
            { 1486, new MobInfo("5", "3", "Enemy2") },
            { 1487, new MobInfo("6", "3", "Enemy2") },
            { 1488, new MobInfo("7", "3", "Enemy2") },
            { 1489, new MobInfo("8", "3", "Enemy2") }, 
            // Unyielding Revenant
            { 1468, new MobInfo("5", "4", "Enemy3") },
            { 1469, new MobInfo("6", "4", "Enemy3") },
            { 1470, new MobInfo("7", "4", "Enemy3") },
            { 1471, new MobInfo("8", "4", "Enemy3") }, 
            // Relentless Dreadknight
            { 1549, new MobInfo("5", "4", "Enemy3") },
            { 1550, new MobInfo("6", "4", "Enemy3") },
            { 1551, new MobInfo("7", "4", "Enemy3") },
            { 1552, new MobInfo("8", "4", "Enemy3") }, 
            // Dominant Frostweaver
            { 1530, new MobInfo("4", "4", "Enemy3") },
            { 1531, new MobInfo("5", "4", "Enemy3") },
            { 1532, new MobInfo("6", "4", "Enemy3") },
            { 1533, new MobInfo("7", "4", "Enemy3") },
            { 1534, new MobInfo("8", "4", "Enemy3") }, 
            // Unerring Bone Archer
            { 1495, new MobInfo("5", "4", "Enemy3") },
            { 1496, new MobInfo("6", "4", "Enemy3") },
            { 1497, new MobInfo("7", "4", "Enemy3") },
            { 1498, new MobInfo("8", "4", "Enemy3") }, 
            // Awakened Swordmaster
            { 1477, new MobInfo("5", "5", "Enemy4") },
            { 1478, new MobInfo("6", "5", "Enemy4") },
            { 1479, new MobInfo("7", "5", "Enemy4") },
            { 1480, new MobInfo("8", "5", "Enemy4") }, 
            // Risen Marksman
            { 1503, new MobInfo("4", "5", "Enemy4") },
            { 1504, new MobInfo("5", "5", "Enemy4") },
            { 1505, new MobInfo("6", "5", "Enemy4") },
            { 1506, new MobInfo("7", "5", "Enemy4") },
            { 1507, new MobInfo("8", "5", "Enemy4") },
            { 1510, new MobInfo("6", "5", "Enemy4") },
            { 1511, new MobInfo("7", "5", "Enemy4") },
            { 1512, new MobInfo("8", "5", "Enemy4") }, 
            // Cryomancer
            { 1540, new MobInfo("5", "5", "Enemy4") },
            { 1541, new MobInfo("6", "5", "Enemy4") },
            { 1542, new MobInfo("7", "5", "Enemy4") },
            { 1543, new MobInfo("8", "5", "Enemy4") }, 
            // Dread Lord
            { 1562, new MobInfo("5", "6", "Enemy5") },
            { 1563, new MobInfo("6", "6", "Enemy5") },
            { 1564, new MobInfo("7", "6", "Enemy5") },
            { 1565, new MobInfo("8", "6", "Enemy5") }, 
            // Nameless Hero
            { 1568, new MobInfo("6", "6", "Enemy5") },
            // Master Cryomancer
            { 1577, new MobInfo("6", "6", "Enemy5") },
            // The Keepers of Albion
            // Wildling
            { 1874, new MobInfo("5", "2", "Enemy1") }, 
            // Knifling
            { 1879, new MobInfo("5", "2", "Enemy1") }, 
// Huntress
{ 1880, new MobInfo("5", "2", "Enemy1") }, 
// Berserk
{ 1875, new MobInfo("5", "2", "Enemy1") }, 
// Druid
{ 1887, new MobInfo("5", "2", "Enemy1") }, 
// Renowed Huntress
{ 1881, new MobInfo("5", "4", "Enemy3") }, 
// Battle-scarred Berserk
{ 1876, new MobInfo("5", "4", "Enemy3") }, 
// Druid
{ 1888, new MobInfo("5", "4", "Enemy3") }, 
// Unrivaled Warrior
{ 1877, new MobInfo("5", "5", "Enemy4") }, 
// Pack Leader
{ 1882, new MobInfo("5", "5", "Enemy4") },
{ 1883, new MobInfo("6", "5", "Enemy4") },
{ 1884, new MobInfo("7", "5", "Enemy4") },
{ 1885, new MobInfo("8", "5", "Enemy4") }, 
// The Disciples of Morgana
// Acolyte Occultist
{ 1196, new MobInfo("4", "2", "Enemy1") },
{ 1197, new MobInfo("5", "2", "Enemy1") },
{ 1198, new MobInfo("6", "2", "Enemy1") },
{ 1199, new MobInfo("7", "2", "Enemy1") },
{ 1200, new MobInfo("8", "2", "Enemy1") }, 
// Suppressor Recruit
{ 1156, new MobInfo("4", "2", "Enemy1") },
{ 1157, new MobInfo("5", "2", "Enemy1") },
{ 1158, new MobInfo("6", "2", "Enemy1") },
{ 1159, new MobInfo("7", "2", "Enemy1") },
{ 1160, new MobInfo("8", "2", "Enemy1") }, 
// Pikeman Recruit
{ 1117, new MobInfo("5", "2", "Enemy1") },
{ 1118, new MobInfo("6", "2", "Enemy1") },
{ 1119, new MobInfo("7", "2", "Enemy1") },
{ 1120, new MobInfo("8", "2", "Enemy1") }, 
// Guard Dogs
{ 1259, new MobInfo("5", "2", "Enemy1") }, // Obsessed Guard Dog
{ 1260, new MobInfo("6", "2", "Enemy1") },
{ 1261, new MobInfo("7", "2", "Enemy1") },
{ 1262, new MobInfo("8", "2", "Enemy1") }, // Zealous Guard Dog
// Summoned Imp
{ 1413, new MobInfo("6", "2", "Enemy1") },
{ 1416, new MobInfo("8", "2", "Enemy1") }, 
// Morgana Squire
{ 3611, new MobInfo("6", "2", "Enemy1") }, 
 // Morgana Acolyte
{ 3601, new MobInfo("6", "2", "Enemy1") },
{ 3602, new MobInfo("7", "2", "Enemy1") }, 
// Occultist
{ 1205, new MobInfo("5", "3", "Enemy2") },
{ 1206, new MobInfo("6", "3", "Enemy2") },
{ 1207, new MobInfo("7", "3", "Enemy2") },
{ 1208, new MobInfo("8", "3", "Enemy2") }, 
// Suppressor
{ 1165, new MobInfo("5", "3", "Enemy2") },
{ 1166, new MobInfo("6", "3", "Enemy2") },
{ 1167, new MobInfo("7", "3", "Enemy2") },
{ 1168, new MobInfo("8", "3", "Enemy2") }, 
// Pikeman
{ 1125, new MobInfo("5", "3", "Enemy2") },
{ 1126, new MobInfo("6", "3", "Enemy2") },
{ 1127, new MobInfo("7", "3", "Enemy2") },
{ 1128, new MobInfo("8", "3", "Enemy2") }, 
// Blackguard Pikeman
{ 1133, new MobInfo("5", "4", "Enemy3") },
{ 1134, new MobInfo("6", "4", "Enemy3") },
{ 1135, new MobInfo("7", "4", "Enemy3") },
{ 1136, new MobInfo("8", "4", "Enemy3") }, 
// Merciless Suppressor
{ 1173, new MobInfo("5", "4", "Enemy3") },
{ 1174, new MobInfo("6", "4", "Enemy3") },
{ 1175, new MobInfo("7", "4", "Enemy3") },
{ 1176, new MobInfo("8", "4", "Enemy3") }, 
 // Dark Paladin
{ 1237, new MobInfo("5", "4", "Enemy3") },
{ 1238, new MobInfo("6", "4", "Enemy3") },
{ 1239, new MobInfo("7", "4", "Enemy3") },
{ 1240, new MobInfo("8", "4", "Enemy3") }, 
// Callous Occultist
{ 1213, new MobInfo("5", "4", "Enemy3") },
{ 1214, new MobInfo("6", "4", "Enemy3") },
{ 1215, new MobInfo("7", "4", "Enemy3") },
{ 1216, new MobInfo("8", "4", "Enemy3") }, 
// Guard Lieutenant
{ 1141, new MobInfo("5", "5", "Enemy4") },
{ 1142, new MobInfo("6", "5", "Enemy4") },
{ 1143, new MobInfo("7", "5", "Enemy4") },
{ 1444, new MobInfo("8", "5", "Enemy4") },
{ 1145, new MobInfo("5", "5", "Enemy4") },
{ 1146, new MobInfo("6", "5", "Enemy4") },
{ 1147, new MobInfo("8", "5", "Enemy4") },
{ 1148, new MobInfo("7", "5", "Enemy4") },
// Suppression Squad Leader
{ 1182, new MobInfo("6", "5", "Enemy4") },
{ 1184, new MobInfo("8", "5", "Enemy4") },
{ 1186, new MobInfo("6", "5", "Enemy4") }, 
 // Ritual Leader
{ 1221, new MobInfo("5", "5", "Enemy4") },
{ 1222, new MobInfo("6", "5", "Enemy4") },
{ 1223, new MobInfo("7", "5", "Enemy4") },
{ 1224, new MobInfo("8", "5", "Enemy4") }, 
// Mistress of Demons
{ 1230, new MobInfo("6", "6", "Enemy5") }, 
// Chosen of Morgana
{ 1246, new MobInfo("6", "6", "Enemy5") },
 // Commander of the GUard
 { 1152, new MobInfo("8", "6", "Enemy5") }, // Commander of the Guard
// The Demons of Hell
// Hellhound
{ 2188, new MobInfo("5", "2", "Enemy1") }, 
// Enthralled Heretic Mage
{ 2194, new MobInfo("5", "2", "Enemy1") }, 
// Demented Heretic Thief
{ 2191, new MobInfo("5", "2", "Enemy1") }, 
// Demonic Slaver
{ 2206, new MobInfo("5", "2", "Enemy1") }, 
// Demonic Sorcerer
{ 2203, new MobInfo("5", "2", "Enemy1") }, 
// Bewildered Heretic Brawler
{ 2218, new MobInfo("5", "2", "Enemy1") }, 
// Deranged Heretic Arbalist
{ 2200, new MobInfo("5", "2", "Enemy1") }, 
// Traps
// Bloated Glutton
{ 2247, new MobInfo("5", "2", "Enemy1") }, 
// Magma Mephit
{ 2246, new MobInfo("1", "2", "Enemy1") }, 
// Arcane Mephit
{ 2248, new MobInfo("1", "2", "Enemy1") }, 
// Volatile Mephit
{ 2249, new MobInfo("1", "2", "Enemy1") }, 
// Ground Trap
{ 2268, new MobInfo("5", "3", "Enemy2") },
{ 2271, new MobInfo("5", "3", "Enemy2") },
{ 2274, new MobInfo("5", "3", "Enemy2") },
{ 2277, new MobInfo("5", "3", "Enemy2") }, 
// Oven Trap
{ 2256, new MobInfo("5", "2", "Enemy1") },
{ 2259, new MobInfo("5", "2", "Enemy1") }, 
// Rotating Trap
{ 2250, new MobInfo("5", "2", "Enemy1") },
{ 2253, new MobInfo("5", "2", "Enemy1") }, 
//Malicous Imp
{ 2185, new MobInfo("5", "2", "Enemy1") },
//Demnonic Watcher
{ 2182, new MobInfo("5", "2", "Enemy1") },
//Infernal Monstrosity
{ 2209, new MobInfo("5", "2", "Enemy1") }, 
//Hiddent Treasure
{ 2240, new MobInfo("5", "9", "HERETICCHEST1") },
{ 2237, new MobInfo("5", "9", "HERETICCHEST1") },
// Random things around bosse
{ 2230, new MobInfo("5", "2", "Enemy1") },
{ 2197, new MobInfo("5", "2", "Enemy1") }, 
// Infernal Horror
{ 2221, new MobInfo("5", "5", "Enemy4") }, 
// Demonic Underlord
{ 2234, new MobInfo("5", "5", "Enemy4") }, 
// Demonic Harbringer
{ 2231, new MobInfo("5", "6", "Enemy5") }, 

// Knighfall Abbey
// Undead Spectral Rat
{ 2595, new MobInfo("5", "2", "Enemy1") },
{ 2596, new MobInfo("6", "2", "Enemy1") },
{ 2597, new MobInfo("7", "2", "Enemy1") },
{ 2598, new MobInfo("8", "2", "Enemy1") },
{ 2599, new MobInfo("5", "2", "Enemy1") },
{ 2500, new MobInfo("6", "2", "Enemy1") },
{ 2501, new MobInfo("7", "2", "Enemy1") },
{ 2502, new MobInfo("8", "2", "Enemy1") }, 

// Undead Spectral Bat
{ 2603, new MobInfo("5", "2", "Enemy1") },
{ 2604, new MobInfo("6", "2", "Enemy1") },
{ 2605, new MobInfo("7", "2", "Enemy1") },
{ 2606, new MobInfo("8", "2", "Enemy1") }, 

// Ghoul
{ 2635, new MobInfo("5", "2", "Enemy1") },
{ 2636, new MobInfo("6", "2", "Enemy1") },
{ 2637, new MobInfo("7", "2", "Enemy1") },
{ 2638, new MobInfo("8", "2", "Enemy1") }, 

// Cursed Fragmenter
{ 2611, new MobInfo("5", "2", "Enemy1") },
{ 2612, new MobInfo("6", "2", "Enemy1") },
{ 2613, new MobInfo("7", "2", "Enemy1") },
{ 2614, new MobInfo("8", "2", "Enemy1") }, 
// Frostweaver
{ 2683, new MobInfo("5", "2", "Enemy1") },
{ 2584, new MobInfo("6", "2", "Enemy1") },
{ 2585, new MobInfo("7", "2", "Enemy1") },
{ 2586, new MobInfo("8", "2", "Enemy1") }, 
// Bone Archer
{ 2643, new MobInfo("5", "2", "Enemy1") },
{ 2644, new MobInfo("6", "2", "Enemy1") },
{ 2645, new MobInfo("7", "2", "Enemy1") },
{ 2646, new MobInfo("8", "2", "Enemy1") }, 
// 
{ 2659, new MobInfo("5", "3", "Enemy2") },
{ 2661, new MobInfo("6", "3", "Enemy2") },
{ 2662, new MobInfo("7", "3", "Enemy2") },
{ 2663, new MobInfo("8", "3", "Enemy2") }, 
// Undead Scorpion
{ 2623, new MobInfo("5", "3", "Enemy2") },
// Relentless Dreadknight
{ 2675, new MobInfo("5", "4", "Enemy3") },
{ 2676, new MobInfo("6", "4", "Enemy3") },
{ 2677, new MobInfo("7", "4", "Enemy3") },
{ 2678, new MobInfo("8", "4", "Enemy3") }, 
// Undead Ghost
{ 2607, new MobInfo("5", "4", "Enemy3") }, 
// Dominant Frostweaver
{ 2687, new MobInfo("5", "4", "Enemy3") }, 
// Awakened Swordmaster
{ 2667, new MobInfo("5", "5", "Enemy4") },
{ 2668, new MobInfo("6", "5", "Enemy4") },
{ 2669, new MobInfo("7", "5", "Enemy4") },
{ 2670, new MobInfo("8", "5", "Enemy4") }, 
// Dread Lord
{ 2679, new MobInfo("5", "6", "Enemy5") }, 
// Master Cryomancer
{ 2695, new MobInfo("5", "6", "Enemy5") }, 
// The Avalonian
// Avalonian Treasure Drone
{ 794, new MobInfo("5", "7", "AVALONMINION6") }, // Green Chest
{ 795, new MobInfo("6", "7", "AVALONMINION6") }, // Green Chest
{ 796, new MobInfo("7", "7", "AVALONMINION6") }, // Green Chest
{ 797, new MobInfo("8", "7", "AVALONMINION6") },
{ 800, new MobInfo("7", "7", "AVALONMINION6") },
{ 802, new MobInfo("5", "7", "AVALONMINION6") }, // Epic Chest
{ 817, new MobInfo("4", "7", "Enemy1") },
{ 820, new MobInfo("4", "7", "Enemy1") },
{ 823, new MobInfo("4", "7", "Enemy1") },
{ 826, new MobInfo("4", "7", "Enemy1") },
// Standard
{ 832, new MobInfo("4", "7", "AVALONPIKEMAN2") },
{ 833, new MobInfo("6", "7", "AVALONPIKEMAN2") },
// Champion
{ 835, new MobInfo("4", "7", "AVALONPIKEMAN1") }, // Pathfinder Spearman
{ 836, new MobInfo("6", "7", "AVALONPIKEMAN1") }, // Pathfinder Spearman
// Standard
{ 838, new MobInfo("4", "7", "AVALONMONK2") }, // Pathfinder Initiate
{ 839, new MobInfo("6", "7", "AVALONMONK2") }, // Pathfinder Initiate
{ 840, new MobInfo("8", "7", "AVALONMONK2") }, // Pathfinder Initiate
// Enchanted
{ 841, new MobInfo("4", "7", "AVALONMONK1") }, 
// Champion
{ 844, new MobInfo("4", "7", "AVALONBERSERK1") }, // Avalonian Warrior
// Pathfinder Hunter
// Standard
{ 850, new MobInfo("4", "7", "AVALONBOWMAN1") },
{ 851, new MobInfo("6", "7", "AVALONBOWMAN1") },
// Pathfinder Wizard
// Standard
{ 862, new MobInfo("4", "7", "AVALONWIZARD2") },
{ 863, new MobInfo("6", "7", "AVALONWIZARD2") },
{ 864, new MobInfo("8", "7", "AVALONWIZARD2") }, 
// Avalonian Acolyte
// Champion
{ 865, new MobInfo("4", "7", "AVALONCLERIC1") }, 
// Pathfinder Mage
// Standard
{ 868, new MobInfo("4", "7", "AVALONMAGE1") },
{ 869, new MobInfo("6", "7", "AVALONMAGE1") }, 
// Scavenger
// Normal
{ 3588, new MobInfo("4", "7", "AVALONWIZARD2") },

// Region Guards

// Bridgewatch
{ 2030, new MobInfo("5", "9", "GUARD") }, // Bridgewatch Guard
{ 2031, new MobInfo("6", "9", "GUARD") }, // Bridgewatch Guard
{ 2032, new MobInfo("4", "9", "GUARD") }, // Bridgewatch City Guard
{ 2033, new MobInfo("5", "9", "CHAMPION_OF_BRIDGEWATCH") }, // Champion of Bridgewatch
{ 2034, new MobInfo("6", "9", "CHAMPION_OF_BRIDGEWATCH") }, // Champion of Bridgewatch

// Martlock
{ 2020, new MobInfo("5", "9", "GUARD") }, // Martlock Guard
{ 2021, new MobInfo("6", "9", "GUARD") }, // Martlock Guard
{ 2022, new MobInfo("4", "9", "GUARD") }, // Martlock City Guard
{ 2023, new MobInfo("5", "9", "CHAMPION_OF_MARTLOCK") }, // Champion of Martlock
{ 2024, new MobInfo("6", "9", "CHAMPION_OF_MARTLOCK") }, // Champion of Martlock

// Thetford
{ 2035, new MobInfo("5", "9", "GUARD") }, // Thetford Guard
{ 2036, new MobInfo("6", "9", "GUARD") }, // Thetford Guard
{ 2037, new MobInfo("4", "9", "GUARD") }, // Thetford City Guard
{ 2038, new MobInfo("5", "9", "CHAMPION_OF_THETFORD") }, // Champion of Thetford
{ 2039, new MobInfo("6", "9", "CHAMPION_OF_THETFORD") }, // Champion of Thetford

// Fort Sterling
{ 2025, new MobInfo("5", "9", "GUARD") }, // Fort Sterling Guard
{ 2026, new MobInfo("6", "9", "GUARD") }, // Fort Sterling Guard
{ 2027, new MobInfo("4", "9", "GUARD") }, // Fort Sterling City Guard
{ 2028, new MobInfo("5", "9", "CHAMPION_OF_FORT_STERLING") }, // Champion of Fort Sterling
{ 2029, new MobInfo("6", "9", "CHAMPION_OF_FORT_STERLING") }, // Champion of Fort Sterling

// Lymhurst
{ 2013, new MobInfo("5", "9", "GUARD") }, // Lymhurst Guard
{ 2014, new MobInfo("6", "9", "GUARD") }, // Lymhurst Guard
{ 2015, new MobInfo("4", "9", "GUARD") }, // Lymhurst City Guard
{ 2016, new MobInfo("5", "9", "CHAMPION_OF_LYMHURST") }, // Champion of Lymhurst
{ 2017, new MobInfo("6", "9", "CHAMPION_OF_LYMHURST") }, // Champion of Lymhurst

// Caerleon
{ 2002, new MobInfo("6", "9", "GUARD") }, // Caerleon City Guard
{ 2004, new MobInfo("6", "9", "BANDIT_RINGLEADER") }, // Bandit Ringleader
{ 2006, new MobInfo("6", "9", "GUARD") }, // Bandit Pillager
{ 2010, new MobInfo("6", "9", "GUARD") }, // Bandit Arsonist

// Guard
{ 2050, new MobInfo("4", "9", "GUARD") }, // Watchtower Mage
{ 2051, new MobInfo("5", "9", "GUARD") }, // Watchtower Mage
{ 2052, new MobInfo("6", "9", "GUARD") }, // Watchtower Mage
{ 2055, new MobInfo("4", "9", "GUARD") }, // Watchtower Swordsman
{ 2056, new MobInfo("5", "9", "GUARD") }, // Watchtower Swordsman
{ 2057, new MobInfo("6", "9", "GUARD") }, // Watchtower Swordsman
{ 2060, new MobInfo("4", "9", "GUARD") }, // Watchtower Arbelist
{ 2061, new MobInfo("5", "9", "GUARD") }, // Watchtower Arbelist
{ 2062, new MobInfo("6", "9", "GUARD") }, // Watchtower Arbelist
{ 2068, new MobInfo("4", "9", "GUARD") }, // Royal Guard Tower
{ 2069, new MobInfo("6", "9", "GUARD") }, // Guard Tower
{ 269, new MobInfo("7", "9", "T7_MOB_WATCHTOWER_ARCANEGUARD_ELITE") }, // Sentry Mage
{ 270, new MobInfo("6", "9", "T6_MOB_WATCHTOWER_ARCANECOLLECTOR_VETERAN") }, // Siphoning Mage

// Hidden treasure
// Forest Biome
{ 684, new MobInfo("4", "9", "ROAMINGCHESTFOREST1") }, // Hidden Treasure - Forest
{ 689, new MobInfo("5", "9", "ROAMINGCHESTFOREST1") }, // Hidden Treasure - Forest
{ 694, new MobInfo("6", "9", "ROAMINGCHESTFOREST1") }, // Hidden Treasure - Forest
// Highland Biome
{ 685, new MobInfo("4", "9", "ROAMINGCHESTHIGHLAND1") }, // Hidden Treasure - Highland
{ 690, new MobInfo("5", "9", "ROAMINGCHESTHIGHLAND1") }, // Hidden Treasure - Highland
{ 695, new MobInfo("6", "9", "ROAMINGCHESTHIGHLAND1") }, // Hidden Treasure - Highland
// Mountain Biome
{ 687, new MobInfo("4", "9", "ROAMINGCHESTMOUNTAIN1") }, // Hidden Treasure - Winter
{ 692, new MobInfo("5", "9", "ROAMINGCHESTMOUNTAIN1") }, // Hidden Treasure - Winter
{ 697, new MobInfo("6", "9", "ROAMINGCHESTMOUNTAIN1") }, // Hidden Treasure - Winter
// Steppe Biome
{ 688, new MobInfo("4", "9", "ROAMINGCHESTSTEPPE1") }, // Hidden Treasure - Steppe
{ 693, new MobInfo("5", "9", "ROAMINGCHESTSTEPPE1") }, // Hidden Treasure - Steppe
{ 698, new MobInfo("6", "9", "ROAMINGCHESTSTEPPE1") }, // Hidden Treasure - Steppe
{ 703, new MobInfo("7", "9", "ROAMINGCHESTSTEPPE1") }, // Hidden Treasure - Steppe
{ 708, new MobInfo("8", "9", "ROAMINGCHESTSTEPPE1") }, // Hidden Treasure - Steppe
// Swamp Biome
{ 686, new MobInfo("4", "9", "ROAMINGCHESTSWAMP1") }, // Hidden Treasure - Swamp
{ 691, new MobInfo("5", "9", "ROAMINGCHESTSWAMP1") }, // Hidden Treasure - Swamp
{ 696, new MobInfo("6", "9", "ROAMINGCHESTSWAMP1") }, // Hidden Treasure - Swamp
// Avalon Biome
{ 679, new MobInfo("4", "9", "HERETICCHEST1") }, // Hidden Treasure - Avalon
{ 680, new MobInfo("5", "9", "HERETICCHEST1") }, // Hidden Treasure - Avalon
{ 681, new MobInfo("6", "9", "HERETICCHEST1") }, // Hidden Treasure - Avalon
{ 682, new MobInfo("7", "9", "HERETICCHEST1") }, // Hidden Treasure - Avalon
// Events
{ 732, new MobInfo("2", "9", "EVENTEASTERCHEST1") },
{ 733, new MobInfo("3", "9", "EVENTEASTERCHEST1") },
{ 734, new MobInfo("4", "9", "EVENTEASTERCHEST1") },
{ 735, new MobInfo("5", "9", "EVENTEASTERCHEST1") },
{ 736, new MobInfo("6", "9", "EVENTEASTERCHEST1") },
{ 737, new MobInfo("7", "9", "EVENTEASTERCHEST1") },
{ 738, new MobInfo("8", "9", "EVENTEASTERCHEST1") }, 
// Tracking Boss
// Earthdaughter
// Solo
{ 20, new MobInfo("4", "9", "Tracking_Earthdaughter") },
{ 21, new MobInfo("5", "9", "Tracking_Earthdaughter") },
{ 22, new MobInfo("6", "9", "Tracking_Earthdaughter") },
{ 23, new MobInfo("7", "9", "Tracking_Earthdaughter") },
{ 24, new MobInfo("8", "9", "Tracking_Earthdaughter") }, 
// Harvester of Souls
// Solo
{ 26, new MobInfo("4", "9", "Tracking_Harvester_of_Souls") },
{ 27, new MobInfo("5", "9", "Tracking_Harvester_of_Souls") },
{ 28, new MobInfo("6", "9", "Tracking_Harvester_of_Souls") },
{ 29, new MobInfo("7", "9", "Tracking_Harvester_of_Souls") },
{ 30, new MobInfo("8", "9", "Tracking_Harvester_of_Souls") }, 
// Group
{ 75, new MobInfo("4", "9", "Tracking_Harvester_of_Souls") },
{ 76, new MobInfo("5", "9", "Tracking_Harvester_of_Souls") },
{ 77, new MobInfo("6", "9", "Tracking_Harvester_of_Souls") },
{ 78, new MobInfo("7", "9", "Tracking_Harvester_of_Souls") },
{ 79, new MobInfo("8", "9", "Tracking_Harvester_of_Souls") }, 
// Shadow Panther
{ 61, new MobInfo("4", "9", "Tracking_Panther") }, // Solo
// Sylvian
{ 61, new MobInfo("4", "9", "Tracking_Sylvian") }, // Solo
// Spirit Bear
{ 65, new MobInfo("4", "9", "Tracking_Spirit_Bear") }, // Solo
// Werewolf
{ 66, new MobInfo("5", "9", "Tracking_Werewolf") }, // Solo
// Hellfire Imp
{ 68, new MobInfo("6", "9", "Tracking_Imp") }, // Solo
// Runestone Golem
{ 69, new MobInfo("6", "9", "Tracking_Runestone_Golem") } // Solo
        };
    }

    // ... (classe MobInfo)
}