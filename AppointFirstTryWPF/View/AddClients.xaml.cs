using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using AppointFirstTryWPF.Model;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace AppointFirstTryWPF.View
{
    /// <summary>
    /// Interaction logic for ClientOverview.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        ObservableCollection<Client> clients;

        public AddClients(Window parentwindow)
        {
            Owner = parentwindow;
            InitializeComponent();
            clients = new();
            ClientGridOverview.ItemsSource = clients;
            LoadClients();
        }

        #region Click Methods
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DataHandler.SaveClients(clients.ToList());
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        private void LoadClients()
        {
            var loadedClients = DataHandler.GetClients();
            clients.Clear();

            if (loadedClients is not null)
            {
                foreach (var client in loadedClients)
                {
                    clients.Add(client);
                }
            }
        }
    }
}
