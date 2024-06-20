using System;
using System.Windows.Controls;
using AOR_Extended_WPF.Properties;
using System.Windows.Controls.Primitives;

namespace AOR_Extended_WPF.Views
{
    public partial class ChestsView : UserControl
    {
        public ChestsView()
        {
            InitializeComponent();
            LoadSettings();
            InitializeEventHandlers();
        }

        private void LoadSettings()
        {
            settingChestGreen.IsChecked = ReturnLocalBool("settingChestGreen");
            settingChestBlue.IsChecked = ReturnLocalBool("settingChestBlue");
            settingChestPurple.IsChecked = ReturnLocalBool("settingChestPurple");
            settingChestYellow.IsChecked = ReturnLocalBool("settingChestYellow");
            settingMistSolo.IsChecked = ReturnLocalBool("settingMistSolo");
            settingMistDuo.IsChecked = ReturnLocalBool("settingMistDuo");
            settingMistE0.IsChecked = ReturnLocalBool("settingMistE0");
            settingMistE1.IsChecked = ReturnLocalBool("settingMistE1");
            settingMistE2.IsChecked = ReturnLocalBool("settingMistE2");
            settingMistE3.IsChecked = ReturnLocalBool("settingMistE3");
            settingMistE4.IsChecked = ReturnLocalBool("settingMistE4");
            settingCage.IsChecked = ReturnLocalBool("settingCage");
            settingDungeonSolo.IsChecked = ReturnLocalBool("settingDungeonSolo");
            settingDungeonDuo.IsChecked = ReturnLocalBool("settingDungeonDuo");
            settingDungeonE0.IsChecked = ReturnLocalBool("settingDungeonE0");
            settingDungeonE1.IsChecked = ReturnLocalBool("settingDungeonE1");
            settingDungeonE2.IsChecked = ReturnLocalBool("settingDungeonE2");
            settingDungeonE3.IsChecked = ReturnLocalBool("settingDungeonE3");
            settingDungeonE4.IsChecked = ReturnLocalBool("settingDungeonE4");
            settingDungeonCorrupted.IsChecked = ReturnLocalBool("settingDungeonCorrupted");
            settingDungeonHellgate.IsChecked = ReturnLocalBool("settingDungeonHellgate");
            settingFootTracksSolo.IsChecked = ReturnLocalBool("settingFootTracksSolo");
            settingFootTracksGroup.IsChecked = ReturnLocalBool("settingFootTracksGroup");
        }

        private void InitializeEventHandlers()
        {
            settingChestGreen.Click += (s, e) => SaveSetting("settingChestGreen", settingChestGreen.IsChecked);
            settingChestBlue.Click += (s, e) => SaveSetting("settingChestBlue", settingChestBlue.IsChecked);
            settingChestPurple.Click += (s, e) => SaveSetting("settingChestPurple", settingChestPurple.IsChecked);
            settingChestYellow.Click += (s, e) => SaveSetting("settingChestYellow", settingChestYellow.IsChecked);
            settingMistSolo.Click += (s, e) => SaveSetting("settingMistSolo", settingMistSolo.IsChecked);
            settingMistDuo.Click += (s, e) => SaveSetting("settingMistDuo", settingMistDuo.IsChecked);
            settingMistE0.Click += (s, e) => SaveSetting("settingMistE0", settingMistE0.IsChecked);
            settingMistE1.Click += (s, e) => SaveSetting("settingMistE1", settingMistE1.IsChecked);
            settingMistE2.Click += (s, e) => SaveSetting("settingMistE2", settingMistE2.IsChecked);
            settingMistE3.Click += (s, e) => SaveSetting("settingMistE3", settingMistE3.IsChecked);
            settingMistE4.Click += (s, e) => SaveSetting("settingMistE4", settingMistE4.IsChecked);
            settingCage.Click += (s, e) => SaveSetting("settingCage", settingCage.IsChecked);
            settingDungeonSolo.Click += (s, e) => SaveSetting("settingDungeonSolo", settingDungeonSolo.IsChecked);
            settingDungeonDuo.Click += (s, e) => SaveSetting("settingDungeonDuo", settingDungeonDuo.IsChecked);
            settingDungeonE0.Click += (s, e) => SaveSetting("settingDungeonE0", settingDungeonE0.IsChecked);
            settingDungeonE1.Click += (s, e) => SaveSetting("settingDungeonE1", settingDungeonE1.IsChecked);
            settingDungeonE2.Click += (s, e) => SaveSetting("settingDungeonE2", settingDungeonE2.IsChecked);
            settingDungeonE3.Click += (s, e) => SaveSetting("settingDungeonE3", settingDungeonE3.IsChecked);
            settingDungeonE4.Click += (s, e) => SaveSetting("settingDungeonE4", settingDungeonE4.IsChecked);
            settingDungeonCorrupted.Click += (s, e) => SaveSetting("settingDungeonCorrupted", settingDungeonCorrupted.IsChecked);
            settingDungeonHellgate.Click += (s, e) => SaveSetting("settingDungeonHellgate", settingDungeonHellgate.IsChecked);
            settingFootTracksSolo.Click += (s, e) => SaveSetting("settingFootTracksSolo", settingFootTracksSolo.IsChecked);
            settingFootTracksGroup.Click += (s, e) => SaveSetting("settingFootTracksGroup", settingFootTracksGroup.IsChecked);
        }

        private bool ReturnLocalBool(string key)
        {
            var value = Settings.Default[key]?.ToString().ToLower();
            return value == "true";
        }

        private void SaveSetting(string key, object value)
        {
            if (value is bool)
            {
                Settings.Default[key] = value.ToString().ToLower(); // Armazena como "true" ou "false"
            }
            else if (value is string)
            {
                Settings.Default[key] = value;
            }
            else
            {
                throw new InvalidOperationException($"Tipo de valor inesperado para '{key}': {value.GetType()}");
            }
            Settings.Default.Save();
        }
    }
}
