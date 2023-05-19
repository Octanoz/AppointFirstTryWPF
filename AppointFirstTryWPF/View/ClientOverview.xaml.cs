﻿using System;
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
    public partial class ClientOverview : Window
    {
        string filePath = @"C:\Users\rheye\source\repos\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Cliënten.json";
        ObservableCollection<Client> clients;

        public ClientOverview(Window parentwindow)
        {
            Owner = parentwindow;
            InitializeComponent();
            SearchBox.Focus();
            clients = new();
            ClientGridOverview.ItemsSource = clients;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} niet gevonden.");
            }

            var json = File.ReadAllText(filePath);
            var loadedClients = JsonConvert.DeserializeObject<List<Client>>(json);

            //start with blank
            //ClientGridOverview.ItemsSource = null;

            clients.Clear();

            if ( clients != null )
            {
                foreach (var client in loadedClients)
                {
                    clients.Add(client);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(clients.ToList(),Formatting.Indented);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, json);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
