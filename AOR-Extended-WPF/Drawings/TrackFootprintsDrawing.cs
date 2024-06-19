using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Drawings
{
    public class TrackFootprintsDrawing : DrawingUtils
    {
        public TrackFootprintsDrawing(Settings settings) : base(settings)
        {
        }

        public void Interpolate(List<Footprint> footprints, double lpX, double lpY, double t)
        {
            foreach (var footprint in footprints)
            {
                var hX = -1 * footprint.PosX + lpX;
                var hY = footprint.PosY - lpY;

                if (footprint.HY == 0 && footprint.HX == 0)
                {
                    footprint.HX = hX;
                    footprint.HY = hY;
                }

                footprint.HX = Lerp(footprint.HX, hX, t);
                footprint.HY = Lerp(footprint.HY, hY, t);
            }
        }

        public void Invalidate(DrawingContext ctx, List<Footprint> footprints)
        {
            var showSolo = settings.ReturnLocalBool("settingFootTracksSolo");
            var showGroup = settings.ReturnLocalBool("settingFootTracksGroup");

            if (!showSolo && !showGroup)
            {
                return;
            }

            foreach (var footprint in footprints)
            {
                var isSolo = footprint.Name.IndexOf("SOLO", StringComparison.OrdinalIgnoreCase) >= 0;
                var isGroup = footprint.Name.IndexOf("GROUP", StringComparison.OrdinalIgnoreCase) >= 0;

                if ((isSolo && !showSolo) || (isGroup && !showGroup))
                {
                    continue;
                }

                var point = TransformPoint(footprint.HX, footprint.HY);

                var imageName = footprint.Name.ToLower(CultureInfo.InvariantCulture).Replace("shared_track_", "");
                if (footprint.Type.Equals("SOLO", StringComparison.OrdinalIgnoreCase))
                {
                    imageName = $"solo_{imageName}";
                }
                else if (footprint.Type.Equals("GROUP", StringComparison.OrdinalIgnoreCase))
                {
                    imageName = $"group_{imageName}";
                }

                DrawCustomImage(ctx, point.X, point.Y, imageName, "Resources", 60);
            }
        }
    }

    public class Footprint
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
