using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace AOR_Extended_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMobList();
        }

        private async void LoadMobList()
        {
            var mobList = await MobInfo.MobService.GetMobList();

            foreach (var mob in mobList)
            {
                Console.WriteLine($"ID: {mob.Key}, Data: {string.Join(", ", mob.Value)}");
            }

            // Use mobList conforme necessário
        }
    }
}