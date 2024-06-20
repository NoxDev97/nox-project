using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AOR_Extended_WPF.Utils
{
    public class DrawingUtils
    {
        public Settings settings;

        private readonly double fontSize = 12;
        private readonly string fontFamily = "Arial";
        private readonly Color textColor = Colors.White;

        public DrawingUtils(Settings settings)
        {
            this.settings = settings;
        }

        public void InitOurPlayerCanvas(Canvas ourPlayerCanvas, DrawingContext context)
        {
            // Certifique-se de que as dimensões do canvas são válidas
            if (ourPlayerCanvas.Width <= 0 || ourPlayerCanvas.Height <= 0)
            {
                MessageBox.Show("Canvas dimensions are not properly set.");
                return;
            }

            double centerX = ourPlayerCanvas.Width / 2;
            double centerY = ourPlayerCanvas.Height / 2;
            DrawFilledCircle(context, centerX, centerY, 7, Colors.Blue);
        }

        public void InitGridCanvas(Canvas canvasBottom, DrawingContext contextBottom)
        {
            DrawBoard(canvasBottom);
        }

        public void ClearGrid(Canvas canvas)
        {
            canvas.Children.Clear();
        }

        public void DrawFilledCircle(DrawingContext context, double x, double y, double radius, Color color)
        {
            context.DrawEllipse(new SolidColorBrush(color), null, new Point(x, y), radius, radius);
        }

        public void InitCanvas(Canvas canvas, DrawingContext context) { }

        public void FillCtx(Canvas canvasBottom, DrawingContext contextBottom)
        {
            contextBottom.DrawRectangle(Brushes.Black, null, new Rect(0, 0, canvasBottom.Width, canvasBottom.Height));
        }

        public void DrawBoard(Canvas canvas)
        {
            var visual = new DrawingVisual();
            using (DrawingContext ctx = visual.RenderOpen())
            {
                var bw = canvas.Width;
                var bh = canvas.Height;
                var p = 0;
                double totalSpace = bh / 10;

                for (double x = 0; x <= bw; x += totalSpace)
                {
                    ctx.DrawLine(new Pen(Brushes.Gray, 1), new Point(0.5 + x + p, p), new Point(0.5 + x + p, bh + p));
                }

                for (double y = 0; y <= bh; y += 50)
                {
                    ctx.DrawLine(new Pen(Brushes.Gray, 1), new Point(p, 0.5 + y + p), new Point(bw + p, 0.5 + y + p));
                }
            }

            var drawingImage = new DrawingImage(visual.Drawing);
            var image = new Image { Source = drawingImage };
            canvas.Children.Add(image);
        }

        public double Lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }

        public void DrawCustomImage(DrawingContext ctx, double x, double y, string imageName, string folder, double size)
        {
            if (string.IsNullOrEmpty(imageName)) return;

            string folderR = string.IsNullOrEmpty(folder) ? "" : folder + "/";
            string src = "/images/" + folderR + imageName + ".png";

            BitmapImage preloadedImage = settings.GetPreloadedImage(src, folder);

            if (preloadedImage == null)
            {
                DrawFilledCircle(ctx, x, y, 10, Colors.RoyalBlue);
                return;
            }

            ctx.DrawImage(preloadedImage, new Rect(x - size / 2, y - size / 2, size, size));
        }

        public Point TransformPoint(double x, double y)
        {
            const double angle = -0.785398;

            double newX = x * angle - y * angle;
            double newY = x * angle + y * angle;
            newX *= 4;
            newY *= 4;

            newX += 250;
            newY += 250;

            return new Point(newX, newY);
        }

        public void DrawText(double xTemp, double yTemp, string text, DrawingContext ctx)
        {
            var formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(fontFamily),
                fontSize,
                new SolidColorBrush(textColor),
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            double x = xTemp;
            double y = yTemp;

            ctx.DrawText(formattedText, new Point(x - formattedText.Width / 2, y));
        }

        public void DrawTextItems(double xTemp, double yTemp, string text, DrawingContext ctx, double size, Color color)
        {
            var formattedText = new FormattedText(
                text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(fontFamily),
                size,
                new SolidColorBrush(color),
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            double x = xTemp;
            double y = yTemp;

            ctx.DrawText(formattedText, new Point(x, y));
        }
    }
}
