using System.Windows.Controls;
using AOR_Extended_WPF.Properties;  // Certifique-se de que esta linha está presente

namespace AOR_Extended_WPF.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            mainWindowMarginX.Text = Settings.Default.mainWindowMarginX ?? "";
            mainWindowMarginY.Text = Settings.Default.mainWindowMarginY ?? "";
            itemsWindowMarginX.Text = Settings.Default.itemsWindowMarginX ?? "";
            itemsWindowMarginY.Text = Settings.Default.itemsWindowMarginY ?? "";
            itemsWidth.Text = Settings.Default.itemsWidth ?? "";
            itemsHeight.Text = Settings.Default.itemsHeight ?? "";
            buttonMarginX.Text = Settings.Default.buttonMarginX ?? "";
            buttonMarginY.Text = Settings.Default.buttonMarginY ?? "";
            settingItemsBorder.IsChecked = Settings.Default.settingItemsBorder;
        }

        private void SaveSettings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Settings.Default.mainWindowMarginX = mainWindowMarginX.Text;
            Settings.Default.mainWindowMarginY = mainWindowMarginY.Text;
            Settings.Default.itemsWindowMarginX = itemsWindowMarginX.Text;
            Settings.Default.itemsWindowMarginY = itemsWindowMarginY.Text;
            Settings.Default.itemsWidth = itemsWidth.Text;
            Settings.Default.itemsHeight = itemsHeight.Text;
            Settings.Default.buttonMarginX = buttonMarginX.Text;
            Settings.Default.buttonMarginY = buttonMarginY.Text;
            Settings.Default.settingItemsBorder = settingItemsBorder.IsChecked ?? false;
            Settings.Default.Save();
        }

        private void LoadSettings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadSettings();
        }
    }
}
