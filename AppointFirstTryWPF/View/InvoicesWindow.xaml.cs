using AppointFirstTryWPF.Model;
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
using System.Windows.Shapes;

namespace AppointFirstTryWPF.View
{
    /// <summary>
    /// Interaction logic for InvoicesWindow.xaml
    /// </summary>
    public partial class InvoicesWindow : Window
    {
        public ObservableCollection<Client> clients { get; set; }
        public List<string> clientFullNames { get; set; }

        public InvoicesWindow()
        {
            InitializeComponent();
            DataContext = this;

            clients = new ObservableCollection<Client>(DataHandler.GetClients());

            clientFullNames = clients.Select(c => $"{c.FirstName} {c.LastName}").ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClientNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientNameComboBox.SelectedItem is string selectedFullName)
            {
                //Find the client with the selected full name
                Client selectedClient = clients.FirstOrDefault(c => $"{c.FirstName} {c.LastName}" == selectedFullName);

                if (selectedClient != null)
                {
                    StreetAddressTextBlock.Text = selectedClient.StreetAddress;
                    PostalCodeTextBlock.Text = selectedClient.PostalCode;
                    TownTextBlock.Text = selectedClient.Town;
                }
                else
                {
                    StreetAddressTextBlock.Text= string.Empty;
                    PostalCodeTextBlock.Text= string.Empty;
                    TownTextBlock.Text= string.Empty;
                }
            }
        }

        /*
         * string templatePath = @"C:\Templates\MyTemplate.dotx";
         * string templateText = File.ReadAllText(templatePath);
         * templateText = templateText.Replace("[TemplateText]", "Hello World!");
         * File.WriteAllText(templatePath, templateText);
         */
    }
}
