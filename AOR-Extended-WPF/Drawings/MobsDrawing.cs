using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Drawings
{
    public class MobsDrawing : DrawingUtils
    {
        public MobsDrawing(Settings settings) : base(settings) { }

        public void Interpolate(List<Mob> mobs, List<Mist> mists, double lpX, double lpY, double t)
        {
            foreach (var mob in mobs)
            {
                var hX = -1 * mob.PosX + lpX;
                var hY = mob.PosY - lpY;

                if (mob.HY == 0 && mob.HX == 0)
                {
                    mob.HX = hX;
                    mob.HY = hY;
                }

                mob.HX = Lerp(mob.HX, hX, t);
                mob.HY = Lerp(mob.HY, hY, t);
            }

            foreach (var mist in mists)
            {
                var hX = -1 * mist.PosX + lpX;
                var hY = mist.PosY - lpY;

                if (mist.HY == 0 && mist.HX == 0)
                {
                    mist.HX = hX;
                    mist.HY = hY;
                }

                mist.HX = Lerp(mist.HX, hX, t);
                mist.HY = Lerp(mist.HY, hY, t);
            }
        }

        public void Invalidate(DrawingContext ctx, List<Mob> mobs, List<Mist> mists)
        {
            foreach (var mob in mobs)
            {
                var point = TransformPoint(mob.HX, mob.HY);

                string imageName = null;
                string imageFolder = null;

                bool drawHp = settings.EnemiesHP;
                bool drawId = settings.EnemiesID;

                if (mob.Type == EnemyType.LivingSkinnable || mob.Type == EnemyType.LivingHarvestable)
                {
                    imageName = $"{mob.Name}_{mob.Tier}_{mob.EnchantmentLevel}";
                    imageFolder = "Resources";

                    drawHp = settings.LivingResourcesHP;
                    drawId = settings.LivingResourcesID;
                }
                else if (mob.Type >= EnemyType.Enemy && mob.Type <= EnemyType.Boss)
                {
                    imageName = mob.Name;
                    imageFolder = "Resources";

                    drawHp = settings.EnemiesHP;
                    drawId = settings.EnemiesID;
                }
                else if (mob.Type == EnemyType.Drone)
                {
                    imageName = mob.Name;
                    imageFolder = "Resources";

                    drawHp = settings.EnemiesHP;
                    drawId = settings.EnemiesID;
                }
                else if (mob.Type == EnemyType.MistBoss)
                {
                    imageName = mob.Name;
                    imageFolder = "Resources";

                    drawHp = settings.EnemiesHP;
                    drawId = settings.EnemiesID;
                }
                else if (mob.Type == EnemyType.Events)
                {
                    imageName = mob.Name;
                    imageFolder = "Resources";

                    drawHp = settings.EnemiesHP;
                    drawId = settings.EnemiesID;
                }

                if (imageName != null && imageFolder != null)
                {
                    DrawCustomImage(ctx, point.X, point.Y, imageName, imageFolder, 40);
                }
                else
                {
                    DrawFilledCircle(ctx, point.X, point.Y, 10, Colors.RoyalBlue);
                }

                if (drawHp)
                {
                    var formattedText = new FormattedText(
                        mob.Health.ToString(),
                        System.Globalization.CultureInfo.InvariantCulture,
                        FlowDirection.LeftToRight,
                        new Typeface("Arial"),
                        12,
                        Brushes.Yellow,
                        VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

                    var textWidth = formattedText.Width;
                    DrawTextItems(ctx, point.X - textWidth / 2, point.Y + 24, mob.Health.ToString(), 12, Brushes.Yellow);
                }

                if (drawId)
                {
                    DrawText(ctx, point.X, point.Y - 20, mob.TypeId.ToString(), 12, Brushes.White);
                }
            }

            foreach (var mist in mists)
            {
                if (!settings.MistEnchants[mist.Enchant])
                {
                    continue;
                }

                if ((settings.MistSolo && mist.Type == 0) || (settings.MistDuo && mist.Type == 1))
                {
                    var point = TransformPoint(mist.HX, mist.HY);
                    DrawCustomImage(ctx, point.X, point.Y, $"mist_{mist.Enchant}", "Resources", 30);
                }
            }
        }

        private void DrawTextItems(DrawingContext ctx, double x, double y, string text, int fontSize, Brush color)
        {
            var formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                fontSize,
                color,
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            ctx.DrawText(formattedText, new Point(x, y));
        }

        private void DrawText(DrawingContext ctx, double x, double y, string text, int fontSize, Brush color)
        {
            var formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                fontSize,
                color,
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            ctx.DrawText(formattedText, new Point(x, y));
        }
    }

    public class Mob
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public int EnchantmentLevel { get; set; }
        public string Health { get; set; }
        public string TypeId { get; set; }
        public EnemyType Type { get; set; }
    }

    public class Mist
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public int Enchant { get; set; }
        public int Type { get; set; }
    }

    public enum EnemyType
    {
        LivingSkinnable,
        LivingHarvestable,
        Enemy,
        Boss,
        Drone,
        MistBoss,
        Events
    }
}
