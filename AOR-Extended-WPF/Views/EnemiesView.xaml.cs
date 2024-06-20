using System;
using System.Windows.Controls;
using AOR_Extended_WPF.Properties;

namespace AOR_Extended_WPF.Views
{
    public partial class EnemiesView : UserControl
    {
        public EnemiesView()
        {
            InitializeComponent();
            LoadSettings();
            InitializeEventHandlers();
        }

        private void LoadSettings()
        {
            settingAllEnemies.IsChecked = ReturnLocalBool("settingAllEnemies");
            settingNormalEnemy.IsChecked = ReturnLocalBool("settingNormalEnemy");
            settingMediumEnemy.IsChecked = ReturnLocalBool("settingMediumEnemy");
            settingEnchantedEnemy.IsChecked = ReturnLocalBool("settingEnchantedEnemy");
            settingMiniBossEnemy.IsChecked = ReturnLocalBool("settingMiniBossEnemy");
            settingBossEnemy.IsChecked = ReturnLocalBool("settingBossEnemy");

            settingBossCrystalSpider.IsChecked = ReturnLocalBool("settingBossCrystalSpider");
            settingBossFairyDragon.IsChecked = ReturnLocalBool("settingBossFairyDragon");
            settingBossVeilWeaver.IsChecked = ReturnLocalBool("settingBossVeilWeaver");
            settingBossGriffin.IsChecked = ReturnLocalBool("settingBossGriffin");

            settingAvaloneDrones.IsChecked = ReturnLocalBool("settingAvaloneDrones");
            settingShowUnmanagedEnemies.IsChecked = ReturnLocalBool("settingShowUnmanagedEnemies");
            settingShowEventEnemies.IsChecked = ReturnLocalBool("settingShowEventEnemies");
            settingMinHP.Text = Settings.Default.settingMinHP ?? "1";

            settingEnemiesHP.IsChecked = ReturnLocalBool("settingEnemiesHP");
            settingEnemiesID.IsChecked = ReturnLocalBool("settingEnemiesID");
        }

        private void InitializeEventHandlers()
        {
            settingAllEnemies.Click += (s, e) => SaveSetting("settingAllEnemies", settingAllEnemies.IsChecked);
            settingNormalEnemy.Click += (s, e) => { SaveSetting("settingNormalEnemy", settingNormalEnemy.IsChecked); HasToCheckCheckAllEnemies(); };
            settingMediumEnemy.Click += (s, e) => { SaveSetting("settingMediumEnemy", settingMediumEnemy.IsChecked); HasToCheckCheckAllEnemies(); };
            settingEnchantedEnemy.Click += (s, e) => { SaveSetting("settingEnchantedEnemy", settingEnchantedEnemy.IsChecked); HasToCheckCheckAllEnemies(); };
            settingMiniBossEnemy.Click += (s, e) => { SaveSetting("settingMiniBossEnemy", settingMiniBossEnemy.IsChecked); HasToCheckCheckAllEnemies(); };
            settingBossEnemy.Click += (s, e) => { SaveSetting("settingBossEnemy", settingBossEnemy.IsChecked); HasToCheckCheckAllEnemies(); };

            settingBossCrystalSpider.Click += (s, e) => SaveSetting("settingBossCrystalSpider", settingBossCrystalSpider.IsChecked);
            settingBossFairyDragon.Click += (s, e) => SaveSetting("settingBossFairyDragon", settingBossFairyDragon.IsChecked);
            settingBossVeilWeaver.Click += (s, e) => SaveSetting("settingBossVeilWeaver", settingBossVeilWeaver.IsChecked);
            settingBossGriffin.Click += (s, e) => SaveSetting("settingBossGriffin", settingBossGriffin.IsChecked);

            settingAvaloneDrones.Click += (s, e) => SaveSetting("settingAvaloneDrones", settingAvaloneDrones.IsChecked);
            settingShowUnmanagedEnemies.Click += (s, e) => SaveSetting("settingShowUnmanagedEnemies", settingShowUnmanagedEnemies.IsChecked);
            settingShowEventEnemies.Click += (s, e) => SaveSetting("settingShowEventEnemies", settingShowEventEnemies.IsChecked);
            settingMinHP.LostFocus += (s, e) => SaveSetting("settingMinHP", settingMinHP.Text);

            settingEnemiesHP.Click += (s, e) => SaveSetting("settingEnemiesHP", settingEnemiesHP.IsChecked);
            settingEnemiesID.Click += (s, e) => SaveSetting("settingEnemiesID", settingEnemiesID.IsChecked);
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

        private void HasToCheckCheckAllEnemies()
        {
            if ((settingNormalEnemy.IsChecked == true &&
                 settingMediumEnemy.IsChecked == true &&
                 settingEnchantedEnemy.IsChecked == true &&
                 settingMiniBossEnemy.IsChecked == true &&
                 settingBossEnemy.IsChecked == true &&
                 settingAllEnemies.IsChecked == false) ||
                (settingNormalEnemy.IsChecked == false ||
                 settingMediumEnemy.IsChecked == false ||
                 settingEnchantedEnemy.IsChecked == false ||
                 settingMiniBossEnemy.IsChecked == false ||
                 settingBossEnemy.IsChecked == false &&
                 settingAllEnemies.IsChecked == true))
            {
                settingAllEnemies.IsChecked = !settingAllEnemies.IsChecked;
                SaveSetting("settingAllEnemies", settingAllEnemies.IsChecked);
            }
        }
    }
}
