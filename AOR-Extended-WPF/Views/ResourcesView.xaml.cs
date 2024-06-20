using AOR_Extended_WPF.Properties;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AOR_Extended_WPF.Views
{
    /// <summary>
    /// Interação lógica para ResourcesView.xam
    /// </summary>
    public partial class ResourcesView : UserControl
    {
        public ResourcesView()
        {
            InitializeComponent();
            LoadSettings();
            InitializeEventHandlers();
        }

        private void LoadSettings()
        {
            // Fiber Settings
            settingFiberE0.IsChecked = ReturnLocalBool("settingFiberE0");
            settingFiberE1.IsChecked = ReturnLocalBool("settingFiberE1");
            settingFiberE2.IsChecked = ReturnLocalBool("settingFiberE2");
            settingFiberE3.IsChecked = ReturnLocalBool("settingFiberE3");
            settingFiberE4.IsChecked = ReturnLocalBool("settingFiberE4");

            // Hide Settings
            settingHideE0.IsChecked = ReturnLocalBool("settingHideE0");
            settingHideE1.IsChecked = ReturnLocalBool("settingHideE1");
            settingHideE2.IsChecked = ReturnLocalBool("settingHideE2");
            settingHideE3.IsChecked = ReturnLocalBool("settingHideE3");
            settingHideE4.IsChecked = ReturnLocalBool("settingHideE4");

            // Wood Settings
            settingWoodE0.IsChecked = ReturnLocalBool("settingWoodE0");
            settingWoodE1.IsChecked = ReturnLocalBool("settingWoodE1");
            settingWoodE2.IsChecked = ReturnLocalBool("settingWoodE2");
            settingWoodE3.IsChecked = ReturnLocalBool("settingWoodE3");
            settingWoodE4.IsChecked = ReturnLocalBool("settingWoodE4");

            // Rock Settings
            settingRockE0.IsChecked = ReturnLocalBool("settingRockE0");
            settingRockE1.IsChecked = ReturnLocalBool("settingRockE1");
            settingRockE2.IsChecked = ReturnLocalBool("settingRockE2");
            settingRockE3.IsChecked = ReturnLocalBool("settingRockE3");
            settingRockE4.IsChecked = ReturnLocalBool("settingRockE4");

            // Ore Settings
            settingOreE0.IsChecked = ReturnLocalBool("settingOreE0");
            settingOreE1.IsChecked = ReturnLocalBool("settingOreE1");
            settingOreE2.IsChecked = ReturnLocalBool("settingOreE2");
            settingOreE3.IsChecked = ReturnLocalBool("settingOreE3");
            settingOreE4.IsChecked = ReturnLocalBool("settingOreE4");

            // Dryad (Fiber) Settings
            settingDryadFiberE0.IsChecked = ReturnLocalBool("settingDryadFiberE0");
            settingDryadFiberE1.IsChecked = ReturnLocalBool("settingDryadFiberE1");
            settingDryadFiberE2.IsChecked = ReturnLocalBool("settingDryadFiberE2");
            settingDryadFiberE3.IsChecked = ReturnLocalBool("settingDryadFiberE3");
            settingDryadFiberE4.IsChecked = ReturnLocalBool("settingDryadFiberE4");

            // Animals (Hide) Settings
            settingAnimalsHideE0.IsChecked = ReturnLocalBool("settingAnimalsHideE0");
            settingAnimalsHideE1.IsChecked = ReturnLocalBool("settingAnimalsHideE1");
            settingAnimalsHideE2.IsChecked = ReturnLocalBool("settingAnimalsHideE2");
            settingAnimalsHideE3.IsChecked = ReturnLocalBool("settingAnimalsHideE3");
            settingAnimalsHideE4.IsChecked = ReturnLocalBool("settingAnimalsHideE4");

            // Spirit (Wood) Settings
            settingSpiritWoodE0.IsChecked = ReturnLocalBool("settingSpiritWoodE0");
            settingSpiritWoodE1.IsChecked = ReturnLocalBool("settingSpiritWoodE1");
            settingSpiritWoodE2.IsChecked = ReturnLocalBool("settingSpiritWoodE2");
            settingSpiritWoodE3.IsChecked = ReturnLocalBool("settingSpiritWoodE3");
            settingSpiritWoodE4.IsChecked = ReturnLocalBool("settingSpiritWoodE4");

            // Elemental (Ore) Settings
            settingElementalOreE0.IsChecked = ReturnLocalBool("settingElementalOreE0");
            settingElementalOreE1.IsChecked = ReturnLocalBool("settingElementalOreE1");
            settingElementalOreE2.IsChecked = ReturnLocalBool("settingElementalOreE2");
            settingElementalOreE3.IsChecked = ReturnLocalBool("settingElementalOreE3");
            settingElementalOreE4.IsChecked = ReturnLocalBool("settingElementalOreE4");

            // Elemental (Rock) Settings
            settingElementalRockE0.IsChecked = ReturnLocalBool("settingElementalRockE0");
            settingElementalRockE1.IsChecked = ReturnLocalBool("settingElementalRockE1");
            settingElementalRockE2.IsChecked = ReturnLocalBool("settingElementalRockE2");
            settingElementalRockE3.IsChecked = ReturnLocalBool("settingElementalRockE3");
            settingElementalRockE4.IsChecked = ReturnLocalBool("settingElementalRockE4");

            // Other Settings
            settingOtherE0.IsChecked = ReturnLocalBool("settingOtherE0");
            settingOtherE1.IsChecked = ReturnLocalBool("settingOtherE1");
            settingOtherE2.IsChecked = ReturnLocalBool("settingOtherE2");
            settingOtherE3.IsChecked = ReturnLocalBool("settingOtherE3");
            settingOtherE4.IsChecked = ReturnLocalBool("settingOtherE4");

            // Show fishing pool
            settingFishingPool.IsChecked = ReturnLocalBool("settingFishingPool");

            // Debug
            settingDebug.IsChecked = ReturnLocalBool("settingDebug");

            // Show Size
            settingShowSize.IsChecked = ReturnLocalBool("settingShowSize");

            // Show HP
            settingShowHP.IsChecked = ReturnLocalBool("settingShowHP");

            // Show ID
            settingShowID.IsChecked = ReturnLocalBool("settingShowID");
        }

        private void InitializeEventHandlers()
        {
            // Fiber Handlers
            settingFiberE0.Click += (s, e) => SaveSetting("settingFiberE0", settingFiberE0.IsChecked);
            settingFiberE1.Click += (s, e) => SaveSetting("settingFiberE1", settingFiberE1.IsChecked);
            settingFiberE2.Click += (s, e) => SaveSetting("settingFiberE2", settingFiberE2.IsChecked);
            settingFiberE3.Click += (s, e) => SaveSetting("settingFiberE3", settingFiberE3.IsChecked);
            settingFiberE4.Click += (s, e) => SaveSetting("settingFiberE4", settingFiberE4.IsChecked);

            // Hide Handlers
            settingHideE0.Click += (s, e) => SaveSetting("settingHideE0", settingHideE0.IsChecked);
            settingHideE1.Click += (s, e) => SaveSetting("settingHideE1", settingHideE1.IsChecked);
            settingHideE2.Click += (s, e) => SaveSetting("settingHideE2", settingHideE2.IsChecked);
            settingHideE3.Click += (s, e) => SaveSetting("settingHideE3", settingHideE3.IsChecked);
            settingHideE4.Click += (s, e) => SaveSetting("settingHideE4", settingHideE4.IsChecked);

            // Wood Handlers
            settingWoodE0.Click += (s, e) => SaveSetting("settingWoodE0", settingWoodE0.IsChecked);
            settingWoodE1.Click += (s, e) => SaveSetting("settingWoodE1", settingWoodE1.IsChecked);
            settingWoodE2.Click += (s, e) => SaveSetting("settingWoodE2", settingWoodE2.IsChecked);
            settingWoodE3.Click += (s, e) => SaveSetting("settingWoodE3", settingWoodE3.IsChecked);
            settingWoodE4.Click += (s, e) => SaveSetting("settingWoodE4", settingWoodE4.IsChecked);

            // Rock Handlers
            settingRockE0.Click += (s, e) => SaveSetting("settingRockE0", settingRockE0.IsChecked);
            settingRockE1.Click += (s, e) => SaveSetting("settingRockE1", settingRockE1.IsChecked);
            settingRockE2.Click += (s, e) => SaveSetting("settingRockE2", settingRockE2.IsChecked);
            settingRockE3.Click += (s, e) => SaveSetting("settingRockE3", settingRockE3.IsChecked);
            settingRockE4.Click += (s, e) => SaveSetting("settingRockE4", settingRockE4.IsChecked);

            // Ore Handlers
            settingOreE0.Click += (s, e) => SaveSetting("settingOreE0", settingOreE0.IsChecked);
            settingOreE1.Click += (s, e) => SaveSetting("settingOreE1", settingOreE1.IsChecked);
            settingOreE2.Click += (s, e) => SaveSetting("settingOreE2", settingOreE2.IsChecked);
            settingOreE3.Click += (s, e) => SaveSetting("settingOreE3", settingOreE3.IsChecked);
            settingOreE4.Click += (s, e) => SaveSetting("settingOreE4", settingOreE4.IsChecked);

            // Dryad (Fiber) Handlers
            settingDryadFiberE0.Click += (s, e) => SaveSetting("settingDryadFiberE0", settingDryadFiberE0.IsChecked);
            settingDryadFiberE1.Click += (s, e) => SaveSetting("settingDryadFiberE1", settingDryadFiberE1.IsChecked);
            settingDryadFiberE2.Click += (s, e) => SaveSetting("settingDryadFiberE2", settingDryadFiberE2.IsChecked);
            settingDryadFiberE3.Click += (s, e) => SaveSetting("settingDryadFiberE3", settingDryadFiberE3.IsChecked);
            settingDryadFiberE4.Click += (s, e) => SaveSetting("settingDryadFiberE4", settingDryadFiberE4.IsChecked);

            // Animals (Hide) Handlers
            settingAnimalsHideE0.Click += (s, e) => SaveSetting("settingAnimalsHideE0", settingAnimalsHideE0.IsChecked);
            settingAnimalsHideE1.Click += (s, e) => SaveSetting("settingAnimalsHideE1", settingAnimalsHideE1.IsChecked);
            settingAnimalsHideE2.Click += (s, e) => SaveSetting("settingAnimalsHideE2", settingAnimalsHideE2.IsChecked);
            settingAnimalsHideE3.Click += (s, e) => SaveSetting("settingAnimalsHideE3", settingAnimalsHideE3.IsChecked);
            settingAnimalsHideE4.Click += (s, e) => SaveSetting("settingAnimalsHideE4", settingAnimalsHideE4.IsChecked);

            // Spirit (Wood) Handlers
            settingSpiritWoodE0.Click += (s, e) => SaveSetting("settingSpiritWoodE0", settingSpiritWoodE0.IsChecked);
            settingSpiritWoodE1.Click += (s, e) => SaveSetting("settingSpiritWoodE1", settingSpiritWoodE1.IsChecked);
            settingSpiritWoodE2.Click += (s, e) => SaveSetting("settingSpiritWoodE2", settingSpiritWoodE2.IsChecked);
            settingSpiritWoodE3.Click += (s, e) => SaveSetting("settingSpiritWoodE3", settingSpiritWoodE3.IsChecked);
            settingSpiritWoodE4.Click += (s, e) => SaveSetting("settingSpiritWoodE4", settingSpiritWoodE4.IsChecked);

            // Elemental (Ore) Handlers
            settingElementalOreE0.Click += (s, e) => SaveSetting("settingElementalOreE0", settingElementalOreE0.IsChecked);
            settingElementalOreE1.Click += (s, e) => SaveSetting("settingElementalOreE1", settingElementalOreE1.IsChecked);
            settingElementalOreE2.Click += (s, e) => SaveSetting("settingElementalOreE2", settingElementalOreE2.IsChecked);
            settingElementalOreE3.Click += (s, e) => SaveSetting("settingElementalOreE3", settingElementalOreE3.IsChecked);
            settingElementalOreE4.Click += (s, e) => SaveSetting("settingElementalOreE4", settingElementalOreE4.IsChecked);

            // Elemental (Rock) Handlers
            settingElementalRockE0.Click += (s, e) => SaveSetting("settingElementalRockE0", settingElementalRockE0.IsChecked);
            settingElementalRockE1.Click += (s, e) => SaveSetting("settingElementalRockE1", settingElementalRockE1.IsChecked);
            settingElementalRockE2.Click += (s, e) => SaveSetting("settingElementalRockE2", settingElementalRockE2.IsChecked);
            settingElementalRockE3.Click += (s, e) => SaveSetting("settingElementalRockE3", settingElementalRockE3.IsChecked);
            settingElementalRockE4.Click += (s, e) => SaveSetting("settingElementalRockE4", settingElementalRockE4.IsChecked);

            // Other Handlers
            settingOtherE0.Click += (s, e) => SaveSetting("settingOtherE0", settingOtherE0.IsChecked);
            settingOtherE1.Click += (s, e) => SaveSetting("settingOtherE1", settingOtherE1.IsChecked);
            settingOtherE2.Click += (s, e) => SaveSetting("settingOtherE2", settingOtherE2.IsChecked);
            settingOtherE3.Click += (s, e) => SaveSetting("settingOtherE3", settingOtherE3.IsChecked);
            settingOtherE4.Click += (s, e) => SaveSetting("settingOtherE4", settingOtherE4.IsChecked);

            // Show fishing pool
            settingFishingPool.Click += (s, e) => SaveSetting("settingFishingPool", settingFishingPool.IsChecked);

            // Debug
            settingDebug.Click += (s, e) => SaveSetting("settingDebug", settingDebug.IsChecked);

            // Show Size
            settingShowSize.Click += (s, e) => SaveSetting("settingShowSize", settingShowSize.IsChecked);

            // Show HP
            settingShowHP.Click += (s, e) => SaveSetting("settingShowHP", settingShowHP.IsChecked);

            // Show ID
            settingShowID.Click += (s, e) => SaveSetting("settingShowID", settingShowID.IsChecked);
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
