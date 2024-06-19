using AOR_Extended_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AOR_Extended_WPF.Drawings
{
    public class MapDrawing : DrawingUtils
    {
        public MapDrawing(Settings settings) : base(settings) { }

        public void Interpolate(Map curr_map, double lpX, double lpY, double t)
        {
            var hX = lpX;
            var hY = -lpY;

            curr_map.HX = Lerp(curr_map.HX, hX, t);
            curr_map.HY = Lerp(curr_map.HY, hY, t);
        }

        public void Draw(DrawingContext ctx, Map curr_map)
        {
            if (curr_map.Id < 0) return;

            DrawImageMap(ctx, curr_map.HX * 4, curr_map.HY * 4, curr_map.Id.ToString(), 825 * 4, curr_map);
        }

        private void DrawImageMap(DrawingContext ctx, double x, double y, string imageName, double size, Map curr_map)
        {
            // Fill background => if no map image or corner to prevent glitch textures
            ctx.DrawRectangle(new SolidColorBrush(Color.FromRgb(26, 28, 35)), null, new System.Windows.Rect(0, 0, 500, 500));

            if (!settings.ShowMapBackground) return;

            if (string.IsNullOrEmpty(imageName) || imageName == "undefined") return;

            var src = $"/images/Maps/{imageName}.png";

            var preloadedImage = settings.GetPreloadedImage(src, "Maps");

            if (preloadedImage == null) return;

            if (preloadedImage != null)
            {
                ctx.PushTransform(new ScaleTransform(1, -1));
                ctx.PushTransform(new TranslateTransform(250, -250));
                ctx.PushTransform(new RotateTransform(-45));
                ctx.PushTransform(new TranslateTransform(-x, y));

                ctx.DrawImage(preloadedImage, new System.Windows.Rect(-size / 2, -size / 2, size, size));
                ctx.Pop();
                ctx.Pop();
                ctx.Pop();
                ctx.Pop();
            }
            else
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await settings.PreloadImageAndAddToList(src, "Maps");
                        Console.WriteLine("Map loaded");
                    }
                    catch
                    {
                        Console.WriteLine("Map not loaded");
                    }
                });
            }
        }
    }

    public class Map
    {
        public double HX { get; set; }
        public double HY { get; set; }
        public int Id { get; set; }
    }
}
