using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace AOR_Extended_WPF.Views
{
    /// <summary>
    /// Lógica interna para DrawingView.xaml
    /// </summary>
    public partial class DrawingView : Window
    {
        private bool nametagRangeEnabled = false;

        public DrawingView()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            showNametagRangeButton.Click += ShowNametagRangeButton_Click;
            toggleGridButton.Click += ToggleGridButton_Click;
        }

        private void ShowNametagRangeButton_Click(object sender, RoutedEventArgs e)
        {
            nametagRangeEnabled = !nametagRangeEnabled;
            showNametagRangeButton.Content = nametagRangeEnabled ? "Hide Nametag Range" : "Show Nametag Range";
            DrawNametagRange();
        }

        private void DrawNametagRange()
        {
            var context = nametagRangeCanvas.RenderTransform as TranslateTransform ?? new TranslateTransform();
            nametagRangeCanvas.RenderTransform = context;
            nametagRangeCanvas.Children.Clear();

            if (nametagRangeEnabled)
            {
                var centerX = nametagRangeCanvas.Width / 2 + 2.5;
                var centerY = nametagRangeCanvas.Height / 2 + 2.5;
                var radius = 190;

                var ellipse = new Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Stroke = Brushes.White,
                    StrokeThickness = 1,
                    RenderTransform = new TranslateTransform(centerX - radius, centerY - radius)
                };

                nametagRangeCanvas.Children.Add(ellipse);
            }
        }

        private void ToggleGridButton_Click(object sender, RoutedEventArgs e)
        {
            var gridCanvasContext = gridCanvas.RenderTransform as TranslateTransform ?? new TranslateTransform();
            gridCanvas.RenderTransform = gridCanvasContext;

            if (toggleGridButton.Content.ToString() == "Disable Grid")
            {
                gridCanvas.Children.Clear();
                toggleGridButton.Content = "Enable Grid";
            }
            else
            {
                InitializeGrid();
                toggleGridButton.Content = "Disable Grid";
            }
        }

        private void InitializeGrid()
        {
            // Your grid initialization code
        }
    }
}
