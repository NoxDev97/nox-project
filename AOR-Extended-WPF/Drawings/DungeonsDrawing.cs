using AOR_Extended_WPF.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace AOR_Extended_WPF.Drawings
{
    public class DungeonsDrawing : DrawingUtils
    {
        public DungeonsDrawing(Settings settings) : base(settings) { }

        public void Interpolate(IEnumerable<Dungeon> dungeons, double lpX, double lpY, double t)
        {
            foreach (var dungeonOne in dungeons)
            {
                double hX = -1 * dungeonOne.PosX + lpX;
                double hY = dungeonOne.PosY - lpY;

                if (dungeonOne.HY == 0 && dungeonOne.HX == 0)
                {
                    dungeonOne.HX = hX;
                    dungeonOne.HY = hY;
                }

                dungeonOne.HX = Lerp(dungeonOne.HX, hX, t);
                dungeonOne.HY = Lerp(dungeonOne.HY, hY, t);
            }
        }

        public void Draw(DrawingContext ctx, IEnumerable<Dungeon> dungeons)
        {
            foreach (var dungeonOne in dungeons)
            {
                if (string.IsNullOrEmpty(dungeonOne.DrawName)) continue;

                var point = TransformPoint(dungeonOne.HX, dungeonOne.HY);
                DrawCustomImage(ctx, point.X, point.Y, dungeonOne.DrawName, "Resources", 40);
            }
        }
    }

    public class Dungeon
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string DrawName { get; set; }
    }
}
