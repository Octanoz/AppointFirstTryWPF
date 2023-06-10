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
        private const string CLIENTDATABASE = @"C:\Users\rheye\source\repos\WPF\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Cliënten.json";
        readonly string filePath = CLIENTDATABASE;
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
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} niet gevonden.");
            }

            var json = File.ReadAllText(filePath);
            List<Client>? clients = JsonConvert.DeserializeObject<List<Client>>(json);

            //start with blank
            ClientGridOverview.ItemsSource = null;

            if (clients is not null)
            {
                ClientGridOverview.ItemsSource = clients;
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var data = (List<Client>)this.ClientGridOverview.ItemsSource;

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, json);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Method intentionally left empty.
        }
    }
}
