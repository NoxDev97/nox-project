using AOR_Extended_WPF.Utils;
using System.Collections.Generic;
using System.Windows.Media;

namespace AOR_Extended_WPF.Drawings
{
    public class HarvestablesDrawing : DrawingUtils
    {
        public HarvestablesDrawing(Settings settings) : base(settings) { }

        public void Interpolate(List<Harvestable> harvestables, double lpX, double lpY, double t)
        {
            foreach (var harvestableOne in harvestables)
            {
                var hX = -1 * harvestableOne.PosX + lpX;
                var hY = harvestableOne.PosY - lpY;

                if (harvestableOne.HY == 0 && harvestableOne.HX == 0)
                {
                    harvestableOne.HX = hX;
                    harvestableOne.HY = hY;
                }

                harvestableOne.HX = Lerp(harvestableOne.HX, hX, t);
                harvestableOne.HY = Lerp(harvestableOne.HY, hY, t);
            }
        }

        public void Invalidate(DrawingContext ctx, List<Harvestable> harvestables)
        {
            foreach (var harvestableOne in harvestables)
            {
                if (harvestableOne.Size <= 0) continue;

                string draw = null;
                int type = harvestableOne.Type;

                if (type >= 11 && type <= 14)
                {
                    draw = $"fiber_{harvestableOne.Tier}_{harvestableOne.Charges}";
                }
                else if (type >= 0 && type <= 5)
                {
                    draw = $"Logs_{harvestableOne.Tier}_{harvestableOne.Charges}";
                }
                else if (type >= 6 && type <= 10)
                {
                    draw = $"rock_{harvestableOne.Tier}_{harvestableOne.Charges}";
                }
                else if (type >= 15 && type <= 22)
                {
                    draw = $"hide_{harvestableOne.Tier}_{harvestableOne.Charges}";
                }
                else if (type >= 23 && type <= 27)
                {
                    draw = $"ore_{harvestableOne.Tier}_{harvestableOne.Charges}";
                }

                if (draw == null) continue;

                var point = TransformPoint(harvestableOne.HX, harvestableOne.HY);

                // Change Resources to Animals/LHarvestables (living harvestables)
                DrawCustomImage(ctx, point.X, point.Y, draw, "Resources", 50);

                if (settings.LivingResourcesID)
                {
                    DrawText(point.X, point.Y + 20, type.ToString(), ctx);
                }

                if (settings.ResourceSize)
                {
                    DrawText(point.X, point.Y - 20, harvestableOne.Size.ToString(), ctx);
                }
            }
        }
    }

    public class Harvestable
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public int Type { get; set; }
        public int Tier { get; set; }
        public int Charges { get; set; }
        public int Size { get; set; }
    }
}
