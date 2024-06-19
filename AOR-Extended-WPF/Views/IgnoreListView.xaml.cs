using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interação lógica para IgnoreListView.xam
    /// </summary>
    public partial class IgnoreListView : UserControl
    {

        
            public ObservableCollection<IgnoreListItem> IgnoreList { get; set; }

            public IgnoreListView()
            {
                InitializeComponent();
                IgnoreList = new ObservableCollection<IgnoreListItem>();
                dataGrid.ItemsSource = IgnoreList;
                LoadSettings();
            }

            private void LoadSettings()
            {
                var storedData = Properties.Settings.Default.IgnoreList;
                if (!string.IsNullOrEmpty(storedData))
                {
                    var items = storedData.Split('|').Select(item => item.Split(',')).Select(parts => new IgnoreListItem { Name = parts[0], Type = parts[1] }).ToList();
                    IgnoreList.Clear();
                    items.ForEach(item => IgnoreList.Add(item));
                }
            }

            private void SaveSettings()
            {
                var storedData = string.Join("|", IgnoreList.Select(item => $"{item.Name},{item.Type}"));
                Properties.Settings.Default.IgnoreList = storedData;
                Properties.Settings.Default.Save();
            }

            private void addItemButton_Click(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrEmpty(nameInput.Text))
                {
                    var newItem = new IgnoreListItem
                    {
                        Name = nameInput.Text,
                        Type = (typeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                    };
                    IgnoreList.Add(newItem);
                    SaveSettings();
                    nameInput.Clear();
                }
            }

            private void resetButton_Click(object sender, RoutedEventArgs e)
            {
                IgnoreList.Clear();
                SaveSettings();
            }

            private void DeleteButton_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                var item = button?.DataContext as IgnoreListItem;
                if (item != null)
                {
                    IgnoreList.Remove(item);
                    SaveSettings();
                }
            }
        }

        public class IgnoreListItem
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
    }
