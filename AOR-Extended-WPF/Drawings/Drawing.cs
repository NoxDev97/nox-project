using System.Windows.Media;

namespace AOR_Extended_WPF.Drawings
{
    public class Drawing
    {
        public Drawing() { }

        public void DrawFilledCircle(DrawingContext context, double x, double y, double radius, Color color)
        {
            var brush = new SolidColorBrush(color);
            var pen = new Pen(brush, 1);
            context.DrawEllipse(brush, pen, new System.Windows.Point(x, y), radius, radius);
        }

        public double Lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }
    }
}
