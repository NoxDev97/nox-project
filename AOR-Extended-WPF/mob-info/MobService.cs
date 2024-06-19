using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOR_Extended_WPF.MobInfo
{
    public static class MobService
    {
        public static async Task<Dictionary<int, List<string>>> GetMobList()
        {
            var mobList = new Dictionary<int, List<string>>();

            // Simulate async operation
            await Task.Delay(100);

            foreach (var mob in Mobs.mobs)
            {
                int id = mob.Key;
                MobInfo info = mob.Value;

                mobList[id] = new List<string> { info.Tier, info.Type, info.Location };
            }

            return mobList;
        }
    }
}
