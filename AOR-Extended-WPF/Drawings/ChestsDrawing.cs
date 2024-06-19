using AOR_Extended_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AOR_Extended_WPF.Drawings
{
    public class ChestsDrawing : DrawingUtils
    {
        public ChestsDrawing(Settings settings) : base(settings)
        {
        }

        public void Interpolate(List<Chest> chests, double lpX, double lpY, double t)
        {
            foreach (var chestOne in chests)
            {
                double hX = -1 * chestOne.PosX + lpX;
                double hY = chestOne.PosY - lpY;

                if (chestOne.HY == 0 && chestOne.HX == 0)
                {
                    chestOne.HX = hX;
                    chestOne.HY = hY;
                }

                chestOne.HX = Lerp(chestOne.HX, hX, t);
                chestOne.HY = Lerp(chestOne.HY, hY, t);
            }
        }

        public void Invalidate(DrawingContext ctx, List<Chest> chests)
        {
            foreach (var chestOne in chests)
            {
                var point = TransformPoint(chestOne.HX, chestOne.HY);

                if (settings.ChestGreen && (chestOne.ChestName.ToLower().Contains("standard") || chestOne.ChestName.ToLower().Contains("green")))
                {
                    DrawCustomImage(ctx, point.X, point.Y, "green", "Resources", 50);
                }
                else if (settings.ChestGreen && (chestOne.ChestName.ToLower().Contains("uncommon") || chestOne.ChestName.ToLower().Contains("blue")))
                {
                    DrawCustomImage(ctx, point.X, point.Y, "blue", "Resources", 50);
                }
                else if (settings.ChestGreen && (chestOne.ChestName.ToLower().Contains("rare") || chestOne.ChestName.ToLower().Contains("purple")))
                {
                    DrawCustomImage(ctx, point.X, point.Y, "rare", "Resources", 50);
                }
                else if (settings.ChestGreen && (chestOne.ChestName.ToLower().Contains("legendary") || chestOne.ChestName.ToLower().Contains("yellow")))
                {
                    DrawCustomImage(ctx, point.X, point.Y, "legendary", "Resources", 50);
                }
            }
        }
    }

    public class Chest
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string ChestName { get; set; }
    }
}
