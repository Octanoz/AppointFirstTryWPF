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
        public ObservableCollection<Invoice> invoices { get; set; }
        public List<Invoice> invoiceData { get; set; }

        public InvoicesWindow()
        {
            InitializeComponent();
            DataContext = this;

            clients = new ObservableCollection<Client>(DataHandler.GetClients());
            invoices = new ObservableCollection<Invoice>(DataHandler.GetInvoices());

            clientFullNames = clients.Select(c => $"{c.FirstName} {c.LastName}").ToList();
            clientFullNames.Insert(0, "Kies een client");
        }        

        private void ClientNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientNameComboBox.SelectedItem is string selectedFullName)
            {
                //Find the client with the selected full name
                Client selectedClient = clients.FirstOrDefault(c => $"{c.FirstName} {c.LastName}" == selectedFullName);
                invoiceData = invoices.Where(i => i.Client_Id == selectedClient?.Id).ToList();

                if (selectedClient != null && selectedFullName != "kies een client")
                {
                    StreetAddressTextBlock.Text = selectedClient.StreetAddress;
                    PostalCodeTextBlock.Text = selectedClient.PostalCode;
                    TownTextBlock.Text = selectedClient.Town;
                    InvoiceGridOverview.ItemsSource = invoiceData;
                }
                else
                {
                    StreetAddressTextBlock.Text= string.Empty;
                    PostalCodeTextBlock.Text= string.Empty;
                    TownTextBlock.Text= string.Empty;
                    InvoiceGridOverview.ItemsSource = invoices;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public enum Year
        {
            Year2022 = 2022,
            Year2023 = 2023,
            Year2024 = 2024,
            Year2025 = 2025
        }
        /*
         * string templatePath = @"C:\Templates\MyTemplate.dotx";
         * string templateText = File.ReadAllText(templatePath);
         * templateText = templateText.Replace("[TemplateText]", "Hello World!");
         * File.WriteAllText(templatePath, templateText);
         */
    }
}
