using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Drawings
{
    public class WispCageDrawing : DrawingUtils
    {
        public WispCageDrawing(Settings settings) : base(settings)
        {
        }

        public void Interpolate(List<WispCage> cages, double lpX, double lpY, double t)
        {
            foreach (var cage in cages)
            {
                var hX = -1 * cage.PosX + lpX;
                var hY = cage.PosY - lpY;

                if (cage.HY == 0 && cage.HX == 0)
                {
                    cage.HX = hX;
                    cage.HY = hY;
                }

                cage.HX = Lerp(cage.HX, hX, t);
                cage.HY = Lerp(cage.HY, hY, t);
            }
        }

        public void Draw(DrawingContext ctx, List<WispCage> cages)
        {
            foreach (var cage in cages)
            {
                var point = TransformPoint(cage.HX, cage.HY);
                DrawCustomImage(ctx, point.X, point.Y, "cage", "Resources", 25);
            }
        }
    }

    public class WispCage
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string Name { get; set; }
    }
}
