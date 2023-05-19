using AppointFirstTryWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        string filePath = @"C:\Users\rheye\source\repos\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Cliënten.json";
        public ManualDataGrid()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} niet gevonden.");
            }

            var json = File.ReadAllText(filePath);
            List<Client>? clients = JsonConvert.DeserializeObject<List<Client>>(json);

            //start with blank
            ClientGridOverview.ItemsSource = null;

            if (clients != null)
            {
                ClientGridOverview.ItemsSource = clients;
            }
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

        }
    }
}
