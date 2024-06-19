using AOR_Extended_WPF.Utils;
using System.Collections.Generic;
using System.Windows.Media;

namespace AOR_Extended_WPF.Drawings
{
    public class FishingDrawing : DrawingUtils
    {
        public FishingDrawing(Settings settings) : base(settings) { }

        public void Interpolate(List<Fish> fishes, double lpX, double lpY, double t)
        {
            foreach (var fish in fishes)
            {
                var hX = -1 * fish.PosX + lpX;
                var hY = fish.PosY - lpY;

                if (fish.HY == 0 && fish.HX == 0)
                {
                    fish.HX = hX;
                    fish.HY = hY;
                }

                fish.HX = Lerp(fish.HX, hX, t);
                fish.HY = Lerp(fish.HY, hY, t);
            }
        }

        public void Draw(DrawingContext ctx, List<Fish> fishes)
        {
            foreach (var fish in fishes)
            {
                var point = TransformPoint(fish.HX, fish.HY);
                DrawCustomImage(ctx, point.X, point.Y, "fish", "Resources", 25);
                DrawText(
                    point.X,
                    point.Y + 25,
                    $"{fish.SizeSpawned}/{fish.TotalSize}",
                    ctx
                );
            }
        }
    }

    public class Fish
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public int SizeSpawned { get; set; }
        public int TotalSize { get; set; }
    }
}
