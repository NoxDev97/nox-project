using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using AOR_Extended_WPF.Utils;

namespace AOR_Extended_WPF.Drawings
{
    public class PlayersDrawing : DrawingUtils
    {
        private Dictionary<string, string> itemsInfo;
        private SpellsInfo spellsInfo;

        public PlayersDrawing(Settings settings, SpellsInfo spellsInfo) : base(settings)
        {
            this.itemsInfo = new Dictionary<string, string>();
            this.spellsInfo = spellsInfo;
        }

        public void UpdateItemsInfo(Dictionary<string, string> newData)
        {
            this.itemsInfo = newData;
        }

        public void UpdateSpellsInfo(SpellsInfo newData)
        {
            this.spellsInfo = newData;
        }

        private double CalculateRemainingCooldown(DateTime currentTime, DateTime spellEndTime)
        {
            var timeDifference = Math.Abs((spellEndTime - currentTime).TotalSeconds);
            return Math.Round(timeDifference, 1);
        }

        private List<Player> SortPlayersByDistance(List<Player> players)
        {
            // Sort all players by their distance
            var sortedPlayers = new List<Player>(players);
            sortedPlayers.Sort((a, b) => a.Distance.CompareTo(b.Distance));

            // Extract the top 3 closest players
            var top3 = sortedPlayers.GetRange(0, Math.Min(3, sortedPlayers.Count));

            // Maintain the original order among the top 3 closest players
            var originalTop3 = players.FindAll(player => top3.Contains(player));

            // Get the rest of the players, excluding the original top 3
            var rest = sortedPlayers.GetRange(3, sortedPlayers.Count - 3);

            // Combine the original top 3 with the sorted rest
            originalTop3.AddRange(rest);
            return originalTop3;
        }

        public void DrawItems(DrawingContext context, Rect canvas, List<Player> players, bool devMode, Dictionary<string, DateTime> castedSpells, bool spellsDev, List<string> alreadyFilteredPlayers, List<string> filteredGuilds, List<string> filteredAlliances)
        {
            double posY = 15;
            var currentTime = DateTime.Now;
            var sortedPlayers = SortPlayersByDistance(players);

            if (players.Count <= 0)
            {
                settings.ClearPreloadedImages("Items");
                return;
            }

            foreach (var playerOne in sortedPlayers)
            {
                var items = playerOne.Items;
                var spells = playerOne.Spells;
                if (filteredGuilds.Contains(playerOne.GuildName.ToUpper()) || filteredAlliances.Contains(playerOne.Alliance.ToUpper()) || alreadyFilteredPlayers.Contains(playerOne.Nickname.ToUpper()))
                    continue;
                if (items == null) continue;

                double posX = 5;
                var total = posY + 20;

                // Show more than few players
                if (total > canvas.Height) break; // Exceed canvas size

                var flagId = playerOne.FlagId ?? 0;
                var flagName = FactionFlagInfo.GetFlagName(flagId);
                DrawCustomImage(context, posX + 10, posY - 5, flagName, "Flags", 20);
                double posTemp = posX + 25;

                var nickname = playerOne.Nickname;
                DrawTextItems(context, posTemp, posY, nickname, 14, Brushes.White);

                posTemp += MeasureTextWidth(context, nickname, 14) + 10;
                DrawTextItems(context, posTemp, posY, $"{playerOne.CurrentHealth}/{playerOne.InitialHealth}", 14, Brushes.Red);

                posTemp += MeasureTextWidth(context, $"{playerOne.CurrentHealth}/{playerOne.InitialHealth}", 14) + 10;

                string itemsListString = "";
                string spellsListString = "";

                posX += 20;
                posY += 25;

                if (items["type"] == "Buffer")
                {
                    posX = 0;
                    posY += 50;
                    continue;
                }

                foreach (var item in items)
                {
                    if (itemsInfo.TryGetValue(item.Key, out var itemInfo) && settings.GetPreloadedImage(itemInfo, "Items") != null)
                    {
                        DrawCustomImage(context, posX, posY, itemInfo, "Items", 40);
                    }

                    posX += 10 + 40;
                    itemsListString += item.Value + " ";
                }

                if (devMode)
                {
                    DrawTextItems(context, posTemp, posY - 5, itemsListString, 14, Brushes.White);
                }

                posY += 45;

                if (spells != null)
                {
                    foreach (var spell in spells.Values)
                    {
                        spellsListString += spell + " ";
                    }

                    posY += 5;
                    if (settings.SettingSpells)
                    {
                        posX = 25;
                        var spellKeys = new[] { "weaponFirst", "weaponSecond", "weaponThird", "helmet", "chest", "boots" };
                        foreach (var key in spellKeys)
                        {
                            string spellIcon = "";
                            if (spells.TryGetValue(key, out var spellId) && spellsInfo.SpellList.TryGetValue(spellId, out var spellInfo))
                            {
                                spellIcon = spellInfo.Icon;
                            }
                            else
                            {
                                spellsInfo.LogMissingSpell(spellId);
                            }

                            if (!string.IsNullOrEmpty(spellIcon) && settings.GetPreloadedImage(spellIcon, "Spells") != null)
                            {
                                DrawCustomImage(context, posX, posY, spellIcon, "Spells", 50);
                            }

                            var spellKey = $"{playerOne.Id}_{spellId}";
                            if (castedSpells.TryGetValue(spellKey, out var endTime))
                            {
                                var remainingTime = CalculateRemainingCooldown(currentTime, endTime);
                                DrawFilledCircle(context, posX, posY, 25, Color.FromArgb(153, 0, 0, 0));
                                DrawText(context, posX, posY, remainingTime.ToString(CultureInfo.InvariantCulture), 12, Brushes.White);
                            }

                            posX += 50;
                        }
                    }
                    if (spellsDev)
                    {
                        DrawTextItems(context, posTemp - 140, posY - 15, spellsListString, 14, Brushes.White);
                    }
                    posY += 45;
                }
            }
        }

        public void Interpolate(List<Player> players, double lpX, double lpY, double t)
        {
            foreach (var playerOne in players)
            {
                var hX = -1 * playerOne.PosX + lpX;
                var hY = playerOne.PosY - lpY;
                var distance = Math.Round(Math.Sqrt((playerOne.PosX - lpX) * (playerOne.PosX - lpX) + (playerOne.PosY - lpY) * (playerOne.PosY - lpY)));
                playerOne.Distance = distance;

                if (playerOne.HY == 0 && playerOne.HX == 0)
                {
                    playerOne.HX = hX;
                    playerOne.HY = hY;
                }

                playerOne.HX = Lerp(playerOne.HX, hX, t);
                playerOne.HY = Lerp(playerOne.HY, hY, t);
            }
        }

        public void Invalidate(DrawingContext context, List<Player> players, List<string> alreadyFilteredPlayers, List<string> filteredGuilds, List<string> filteredAlliances)
        {
            var showFilteredPlayers = settings.ReturnLocalBool("settingDrawFilteredPlayers");
            var showFilteredGuilds = settings.ReturnLocalBool("settingDrawFilteredGuilds");
            var showFilteredAlliances = settings.ReturnLocalBool("settingDrawFilteredAlliances");

            foreach (var playerOne in players)
            {
                var point = TransformPoint(playerOne.HX, playerOne.HY);
                var space = 0;

                if (!showFilteredGuilds && filteredGuilds.Contains(playerOne.GuildName.ToUpper()))
                    continue;
                if (!showFilteredAlliances && filteredAlliances.Contains(playerOne.Alliance.ToUpper()))
                    continue;
                if (!showFilteredPlayers && alreadyFilteredPlayers.Contains(playerOne.Nickname.ToUpper()))
                    continue;

                var flagId = playerOne.FlagId ?? 0;
                var flagName = FactionFlagInfo.GetFlagName(flagId);

                var isFiltered = filteredGuilds.Contains(playerOne.GuildName.ToUpper()) || filteredAlliances.Contains(playerOne.Alliance.ToUpper()) || alreadyFilteredPlayers.Contains(playerOne.Nickname.ToUpper());
                var iconName = isFiltered ? "guild" : flagName;

                if (settings.SettingMounted)
                {
                    context.DrawEllipse(null, new Pen(playerOne.Mounted ? Brushes.Green : Brushes.Red, 3), new Point(point.X, point.Y), 11, 11);
                }

                DrawCustomImage(context, point.X, point.Y, iconName, "Flags", 20);

                if (settings.SettingNickname)
                {
                    space += 23;
                    DrawText(context, point.X, point.Y + space, playerOne.Nickname, 12, Brushes.White);
                }

                if (settings.SettingDistance)
                {
                    DrawText(context, point.X, point.Y - 14, $"{playerOne.Distance}m", 12, Brushes.White);
                }

                if (settings.SettingHealth)
                {
                    space += 6;
                    var percent = (double)playerOne.CurrentHealth / playerOne.InitialHealth;
                    var width = 60;
                    var height = 7;

                    context.DrawRectangle(Brushes.Black, null, new Rect(point.X - width / 2, point.Y - height / 2 + space, width, height));
                    context.DrawRectangle(Brushes.Red, null, new Rect(point.X - width / 2, point.Y - height / 2 + space, width * percent, height));
                }

                if (settings.SettingGuild)
                {
                    space += 14;
                    if (playerOne.GuildName != "undefined")
                    {
                        DrawText(context, point.X, point.Y + space, playerOne.GuildName, 12, Brushes.White);
                    }
                }
            }
        }

        private double MeasureTextWidth(DrawingContext context, string text, int fontSize)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                fontSize,
                Brushes.White,
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            return formattedText.Width;
        }

        private void DrawTextItems(DrawingContext context, double x, double y, string text, int fontSize, Brush color)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                fontSize,
                color,
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            context.DrawText(formattedText, new Point(x, y));
        }

        private void DrawText(DrawingContext context, double x, double y, string text, int fontSize, Brush color)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                fontSize,
                color,
                VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

            context.DrawText(formattedText, new Point(x, y));
        }
    }

    public class Player
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double HX { get; set; }
        public double HY { get; set; }
        public string Nickname { get; set; }
        public int CurrentHealth { get; set; }
        public int InitialHealth { get; set; }
        public string GuildName { get; set; }
        public string Alliance { get; set; }
        public int? FlagId { get; set; }
        public bool Mounted { get; set; }
        public Dictionary<string, string> Items { get; set; }
        public Dictionary<string, string> Spells { get; set; }
        public double Distance { get; set; }
        public string Id { get; set; }
    }

    public static class FactionFlagInfo
    {
        public static string GetFlagName(int flagId)
        {
            // Implement your flag name logic here
            return "default_flag";
        }
    }

    public class SpellsInfo
    {
        public Dictionary<string, Spell> SpellList { get; set; }

        public void LogMissingSpell(string spellId)
        {
            // Implement your logging logic here
        }
    }

    public class Spell
    {
        public string Icon { get; set; }
    }
}
