using AppointFirstTryWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;

namespace AppointFirstTryWPF.View
{
    /// <summary>
    /// Interaction logic for ManualDataGrid.xaml
    /// </summary>
    public partial class ManualDataGrid : Window
    {
        ObservableCollection<Client> clients;

        public ManualDataGrid()
        {
            InitializeComponent();
            SearchBox.Focus();
            clients = new();
            ClientGridOverview.ItemsSource = clients;
            LoadClients();
        }

        private void LoadClients()
        {
            clients.Clear();
            var loadedClients = DataHandler.GetClients();

            if (loadedClients is not null)
            {
                foreach (var client in loadedClients)
                {
                    clients.Add(client);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Method intentionally left empty.
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //After changing the modalwindow constructor to take an owner window you will need to specify that owner in the initialization. so that's why we added (this).
            ClientOverview clientOverview = new ClientOverview(this);
            Opacity = 0.6;
            clientOverview.ShowDialog();
            Opacity = 1;
        }
    }
}
