using System.Windows.Controls;
using AOR_Extended_WPF.Properties;  // Adicione esta linha

namespace AOR_Extended_WPF.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            LoadSettings();
            InitializeEventHandlers();
        }

        private void LoadSettings()
        {
            settingOnOff.IsChecked = ReturnLocalBool("settingOnOff");
            settingNickname.IsChecked = ReturnLocalBool("settingNickname");
            settingHealth.IsChecked = ReturnLocalBool("settingHealth");
            settingMounted.IsChecked = ReturnLocalBool("settingMounted");
            settingItems.IsChecked = ReturnLocalBool("settingItems");
            settingItemsDev.IsChecked = ReturnLocalBool("settingItemsDev");
            settingSpells.IsChecked = ReturnLocalBool("settingSpells");
            settingSpellsDev.IsChecked = ReturnLocalBool("settingSpellsDev");
            settingDistance.IsChecked = ReturnLocalBool("settingDistance");
            settingGuild.IsChecked = ReturnLocalBool("settingGuild");
            settingSound.IsChecked = ReturnLocalBool("settingSound");
            settingDrawFilteredPlayers.IsChecked = ReturnLocalBool("settingDrawFilteredPlayers");
            settingDrawFilteredGuilds.IsChecked = ReturnLocalBool("settingDrawFilteredGuilds");
            settingDrawFilteredAlliances.IsChecked = ReturnLocalBool("settingDrawFilteredAlliances");
        }

        private void InitializeEventHandlers()
        {
            settingOnOff.Click += (s, e) => SaveSetting("settingOnOff", settingOnOff.IsChecked);
            settingNickname.Click += (s, e) => SaveSetting("settingNickname", settingNickname.IsChecked);
            settingHealth.Click += (s, e) => SaveSetting("settingHealth", settingHealth.IsChecked);
            settingMounted.Click += (s, e) => SaveSetting("settingMounted", settingMounted.IsChecked);
            settingItems.Click += (s, e) => SaveSetting("settingItems", settingItems.IsChecked);
            settingItemsDev.Click += (s, e) => SaveSetting("settingItemsDev", settingItemsDev.IsChecked);
            settingSpells.Click += (s, e) => SaveSetting("settingSpells", settingSpells.IsChecked);
            settingSpellsDev.Click += (s, e) => SaveSetting("settingSpellsDev", settingSpellsDev.IsChecked);
            settingDistance.Click += (s, e) => SaveSetting("settingDistance", settingDistance.IsChecked);
            settingGuild.Click += (s, e) => SaveSetting("settingGuild", settingGuild.IsChecked);
            settingSound.Click += (s, e) => SaveSetting("settingSound", settingSound.IsChecked);
            settingDrawFilteredPlayers.Click += (s, e) => SaveSetting("settingDrawFilteredPlayers", settingDrawFilteredPlayers.IsChecked);
            settingDrawFilteredGuilds.Click += (s, e) => SaveSetting("settingDrawFilteredGuilds", settingDrawFilteredGuilds.IsChecked);
            settingDrawFilteredAlliances.Click += (s, e) => SaveSetting("settingDrawFilteredAlliances", settingDrawFilteredAlliances.IsChecked);
        }

        private bool ReturnLocalBool(string key)
        {
            var value = Settings.Default[key]?.ToString();
            return value == "true";
        }

        private void SaveSetting(string key, bool? value)
        {
            Settings.Default[key] = value.ToString();
            Settings.Default.Save();
        }
    }
}
