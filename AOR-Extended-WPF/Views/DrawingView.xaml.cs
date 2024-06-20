using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AOR_Extended_WPF.Utils;
using AOR_Extended_WPF.Drawings;
using AOR_Extended_WPF.Handlers;

namespace AOR_Extended_WPF.Views
{
    public partial class DrawingView : Window
    {
        private bool nametagRangeEnabled = false;
        private Settings settings;
        private DrawingUtils drawingUtils;
        private ChestsDrawing chestsDrawing;
        private HarvestablesHandler harvestablesHandler;
        private DungeonsHandler dungeonsHandler;
        private PlayersHandler playersHandler;
        private TrackFootprintsHandler trackFootprintsHandler;
        private WispCageHandler wispCageHandler;
        private FishingHandler fishingHandler;
        private MobsHandler mobsHandler;

        public DrawingView()
        {
            InitializeComponent();
            InitializeControls();

            settings = new Settings();
            drawingUtils = new DrawingUtils(settings);
            chestsDrawing = new ChestsDrawing(settings);
            harvestablesHandler = new HarvestablesHandler(settings);
            dungeonsHandler = new DungeonsHandler(settings);
            playersHandler = new PlayersHandler(settings, settings.SpellsInfo);
            trackFootprintsHandler = new TrackFootprintsHandler(settings);
            wispCageHandler = new WispCageHandler(settings);
            fishingHandler = new FishingHandler(settings);
            mobsHandler = new MobsHandler(settings);

            this.Loaded += DrawingView_Loaded;
        }

        private void DrawingView_Loaded(object sender, RoutedEventArgs e)
        {
            DrawInitialElements();
        }

        private void InitializeControls()
        {
            showNametagRangeButton.Click += ShowNametagRangeButton_Click;
            toggleGridButton.Click += ToggleGridButton_Click;
        }

        private void ShowNametagRangeButton_Click(object sender, RoutedEventArgs e)
        {
            nametagRangeEnabled = !nametagRangeEnabled;
            showNametagRangeButton.Content = nametagRangeEnabled ? "Esconder área de segurança" : "Mostrar área de segurança";
            DrawNametagRange();
        }

        private void DrawNametagRange()
        {
            nametagRangeCanvas.Children.Clear();

            if (nametagRangeEnabled)
            {
                double centerX = nametagRangeCanvas.Width / 2 + 2.5;
                double centerY = nametagRangeCanvas.Height / 2 + 2.5;
                double radius = 190;

                Ellipse nametagRangeEllipse = new Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    RenderTransform = new TranslateTransform(centerX - radius, centerY - radius)
                };

                nametagRangeCanvas.Children.Add(nametagRangeEllipse);
            }
        }

        private void ToggleGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (toggleGridButton.Content.ToString() == "Desabilitar grade")
            {
                ClearGrid();
                toggleGridButton.Content = "Ativar grade";
            }
            else
            {
                InitializeGrid();
                toggleGridButton.Content = "Desabilitar grade";
            }
        }

        private void InitializeGrid()
        {
            drawingUtils.DrawBoard(gridCanvas);
        }

        private void ClearGrid()
        {
            drawingUtils.ClearGrid(gridCanvas);
        }

        private void DrawInitialElements()
        {
            var visual = new DrawingVisual();

            using (DrawingContext ctx = visual.RenderOpen())
            {
                drawingUtils.InitOurPlayerCanvas(ourPlayerCanvas, ctx);
                drawingUtils.InitGridCanvas(gridCanvas, ctx);

                foreach (var harvestable in harvestablesHandler.HarvestableList)
                {
                    var point = drawingUtils.TransformPoint(harvestable.PosX, harvestable.PosY);
                    drawingUtils.DrawFilledCircle(ctx, point.X, point.Y, 5, Colors.Green);
                }

                foreach (var dungeon in dungeonsHandler.DungeonList)
                {
                    var point = drawingUtils.TransformPoint(dungeon.PosX, dungeon.PosY);
                    drawingUtils.DrawFilledCircle(ctx, point.X, point.Y, 5, Colors.Red);
                }
            }

            var drawingImage = new DrawingImage(visual.Drawing);
            var image = new Image { Source = drawingImage };
            ourPlayerCanvas.Children.Add(image);
        }
    }
}
