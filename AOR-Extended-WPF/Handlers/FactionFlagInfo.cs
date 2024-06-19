using System.Collections.Generic;

namespace AOR_Extended_WPF.Handlers
{
    public static class FactionFlagInfo
    {
        public static readonly Dictionary<int, string> Flags = new Dictionary<int, string>
        {
            { 0, "FRIENDLY" },
            { 1, "MARTLOCK" },
            { 2, "LYMHURST" },
            { 3, "BRIDGEWATCH" },
            { 4, "FORTSTERLING" },
            { 5, "THETFORD" },
            { 6, "CAERLEON" },
            { 255, "HOSTILE" }
        };
    }
}
