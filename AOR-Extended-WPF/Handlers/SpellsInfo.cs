using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpellsNamespace
{
    public class SpellsInfo
    {
        private Dictionary<int, Spell> spellList;
        private HashSet<int> missingSpellIds;

        public SpellsInfo()
        {
            spellList = new Dictionary<int, Spell>();
            missingSpellIds = new HashSet<int>();

            ReadMissingSpellsFromLocalStorage();
        }

        public void AddItem(int id, double cooldown, string icon, int? parentId = null)
        {
            if (!spellList.ContainsKey(id))
            {
                spellList[id] = new Spell(id, cooldown, icon, parentId);
            }
        }

        public void LogMissingSpell(int id)
        {
            if (!spellList.ContainsKey(id))
            {
                missingSpellIds.Add(id);
                Console.WriteLine($"Missing spell ID: {id}");
                WriteMissingSpellsToLocalStorage();
            }
        }

        private void WriteMissingSpellsToLocalStorage()
        {
            string missingSpellsJson = JsonConvert.SerializeObject(missingSpellIds);
            // Save `missingSpellsJson` to a local file or other storage
            System.IO.File.WriteAllText("missingSpells.json", missingSpellsJson);
        }

        private void ReadMissingSpellsFromLocalStorage()
        {
            try
            {
                // Read `missingSpellsJson` from a local file or other storage
                string missingSpellsJson = System.IO.File.ReadAllText("missingSpells.json");
                missingSpellIds = JsonConvert.DeserializeObject<HashSet<int>>(missingSpellsJson) ?? new HashSet<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading missing spells from storage: {ex.Message}");
            }
        }

        public void InitSpells()
        {
            AddItem(2085, 0, "SHAPE_Q_CAST");
            AddItem(2086, 0, "SHAPE_Q_CAST_STACK");
            AddItem(2087, 0, "SHAPE_Q_CAST_AREA");
            AddItem(2088, 6, "SHAPE_Q_DAMAGE_AND_SHIELD");
            AddItem(2089, 0, "SHAPE_Q_DAMAGE_AND_SHIELD_DAMAGE");
            AddItem(2090, 0, "SHAPE_Q_DAMAGE_AND_SHIELD_BUBBLE");
            AddItem(2091, 2, "SHAPE_Q_SKILLSHOT");
            AddItem(2092, 0, "SHAPE_Q_SKILLSHOT_EFFECT");
            AddItem(2093, 0, "SHAPE_Q_SKILLSHOT_ULT_APPLY");
            AddItem(2094, 2, "SHAPE_Q_SKILLSHOT_ULT", 2093);
            AddItem(2095, 0, "SHAPE_Q_SKILLSHOT_ULT_FEROCITY");
            AddItem(2096, 0, "SHAPE_Q_SKILLSHOT_ULT_EFFECT");
            AddItem(2097, 4, "SHAPE_Q_CONE_MELEE");
            AddItem(2098, 0, "SHAPE_Q_CONE_FEROCITY");
            AddItem(2099, 0, "SHAPE_Q_CONE_DAMAGE");
            AddItem(2100, 0, "SHAPE_Q_CONE_PIERCE");
            AddItem(2101, 8, "SHAPE_W_DAMAGE_AOE");
            AddItem(2102, 0, "SHAPE_W_DAMAGE_AOE_FEROCITY");
            AddItem(2103, 0, "SHAPE_W_DAMAGE_AOE_EFFECT");
            AddItem(2104, 15, "SHAPE_W_POLYMORPH", 2223);
            AddItem(2105, 0, "SHAPE_W_POLYMORPH_EFFECT");
            AddItem(2106, 0, "SHAPE_W_POLYMORPH_EFFECT_HIT");
            AddItem(2107, 0, "SHAPE_W_POLYMORPH_EFFECT_PLAYER");
            AddItem(2108, 0, "SHAPE_W_POLYMORPH_EFFECT_TRANSFORMATION");
            AddItem(2109, 0, "SHAPE_W_POLYMORPH_IMMUNITY");
            AddItem(2110, 0, "SHAPE_W_POLYMORPH_EFFECT_HEALTH_REDUCTION");
            AddItem(2111, 0, "SHAPE_W_POLYMORPH_EFFECT_DAMAGE");
            AddItem(2112, 15, "SHAPE_W_AREA_PULL");
            AddItem(2113, 0, "SHAPE_W_AREA_PULL_EFFECT");
            AddItem(2114, 0, "SHAPE_W_AREA_PULL_DAMAGE");
            AddItem(2115, 0, "SHAPE_W_AREA_PULL_IMMUNITY");
            AddItem(2116, 0, "SHAPE_W_AREA_PULL_ROOT");
            AddItem(2117, 15, "SHAPE_W_TETHERBEAM");
            AddItem(2118, 0, "SHAPE_W_TETHERBEAM_CHECK");
            AddItem(2119, 0, "SHAPE_W_TETHERBEAM_CHECK_EFFECT");
            AddItem(2120, 0, "SHAPE_W_TETHERBEAM_ALLY");
            AddItem(2121, 0, "SHAPE_W_TETHERBEAM_ALLYNONPARTY");
            AddItem(2122, 0, "SHAPE_W_TETHERBEAM_ALLY_BUFF");
            AddItem(2123, 0, "SHAPE_W_TETHERBEAM_CHECK_ALLY");
            AddItem(2124, 0, "SHAPE_W_TETHERBEAM_CHECK_ALLY_EFFECT");
            AddItem(2125, 0, "SHAPE_W_TETHERBEAM_ENEMY");
            AddItem(2126, 15, "SHAPE_W_TETHERBEAM_ALLY_EFFECT", 2125);
            AddItem(2127, 0, "SHAPE_W_TETHERBEAM_ALLY_SHIELD");
            AddItem(2128, 5, "BEAR_GROUND_SMASH");
            AddItem(2129, 0, "BEAR_GROUND_SMASH_DAMAGE");
            AddItem(2130, 0, "BEAR_GROUND_SMASH_STUN");
            AddItem(2131, 0, "BEAR_DASH_THROUGH");
            AddItem(2132, 0, "BEAR_DASH_THROUGH_AURA_EFFECT");
            AddItem(2133, 0, "BEAR_DASH_THROUGH_DEBUFF");
            AddItem(2134, 0, "BEAR_DASH_THROUGH_DAMAGE");
            AddItem(2135, 0, "BEAR_DASH_THROUGH_KNOCKBACK");
            AddItem(2136, 18, "BEAR_ROAR", 2131);
            AddItem(2137, 0, "BEAR_ROAR_EFFECT");
            AddItem(2138, 0, "BEAR_ROAR_FEAR");
            AddItem(2139, 0, "BEAR_ROAR_DAMAGE");
            AddItem(2140, 2, "WEREWOLF_TEAR_APART");
            AddItem(2141, 0, "WEREWOLF_TEAR_APART_FEROCITY_EFFECT");
            AddItem(2142, 0, "WEREWOLF_TEAR_APART_EFFECT");
            AddItem(2143, 0, "WEREWOLF_TEAR_APART_VFX");
            AddItem(2144, 0, "WEREWOLF_TEAR_APART_PUDDLE_EFFECT");
            AddItem(2145, 5, "WEREWOLF_DASH");
            AddItem(2146, 0, "WEREWOLF_DASH_EFFECT");
            AddItem(2147, 0, "WEREWOLF_DASH_END");
            AddItem(2148, 0, "WEREWOLF_DASH_BUFF");
            AddItem(2149, 0, "WEREWOLF_DASH_VFX");
            AddItem(2150, 3, "FLAME_ORB");
            AddItem(2151, 0, "FLAME_ORB_CD_RESET");
            AddItem(2152, 0, "FLAME_ORB_PASSTHROUGH_EFFECT");
            AddItem(2153, 6, "FLAME_ORB_TELEPORT_EFFECT", 2150);
            AddItem(2154, 0, "FLAME_ORB_COLLISION_EFFECT");
            AddItem(2155, 12, "IMP_BEAM");
            AddItem(2157, 0, "IMP_BEAM_PROJECTILE_RIGHT");
            AddItem(2158, 0, "IMP_BEAM_PROJECTILE_LEFT");
            AddItem(2159, 5, "AVALON_EAGLE_LASER");
            AddItem(2160, 0, "AVALON_EAGLE_LASER_EFFECT");
            AddItem(2161, 0, "AVALON_EAGLE_LASER_HIT");
            AddItem(2162, 0, "AVALON_EAGLE_LASER_HIT_DAMAGE");
            AddItem(2163, 10, "AVALON_EAGLE_TELEPORT");
            AddItem(2164, 0, "AVALON_EAGLE_TELEPORT_EFFECT");
            AddItem(2165, 0, "AVALON_EAGLE_TELEPORT_HIT");
            AddItem(2166, 0, "AVALON_EAGLE_TELEPORT_DAMAGE");
            AddItem(2167, 0, "AVALON_EAGLE_TELEPORT_BUFF");
            AddItem(2168, 0, "AVALON_EAGLE_TELEPORT_VFX");
            AddItem(2169, 0, "IMP_GROUND_ATTACK");
            AddItem(2170, 0, "IMP_GROUND_ATTACK_EFFECT");
            AddItem(2171, 10, "IMP_SUMMON_MINIONS");
            AddItem(2172, 0, "IMP_SUMMON_MINIONS_EFFECT");
            AddItem(2173, 0, "IMP_SUMMON_MINIONS_BUFF");
            AddItem(2174, 0, "IMP_SUMMON_MINIONS_SUMMON");
            AddItem(2175, 0, "IMP_SUMMON_MINIONS_SUMMON_DAMAGE");
            AddItem(2176, 0, "IMP_SUMMON_MINIONS_SUMMON_DAMAGE_EFFECT");
            AddItem(2177, 0, "IMP_SUMMON_MINIONS_SUMMON_EFFECT");
            AddItem(2178, 0, "SHAPE_W_TETHERBEAM_CHECK_ENEMY");
            AddItem(2179, 0, "SHAPE_W_TETHERBEAM_CHECK_ENEMY_EFFECT");
            AddItem(2180, 0, "SHAPE_W_TETHERBEAM_CHECK_EFFECT", 2179);
            AddItem(2181, 0, "SHAPE_W_TETHERBEAM_DAMAGE");
            AddItem(2182, 0, "SHAPE_W_TETHERBEAM_DAMAGE_ENEMY");
            AddItem(2183, 0, "SHAPE_W_TETHERBEAM_DAMAGE_ENEMY_EFFECT");
            AddItem(2184, 0, "SHAPE_W_TETHERBEAM_EFFECT_ENEMY", 2179);
            AddItem(2185, 0, "SHAPE_W_TETHERBEAM_VFX");
        }

        public Dictionary<int, Spell> GetSpellList()
        {
            return spellList;
        }
    }
}
