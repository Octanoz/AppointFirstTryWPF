using AppointFirstTryWPF.Model;
using AppointFirstTryWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppointFirstTryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> clients { get; set; }
        public List<string> clientFullNames { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            clients = new ObservableCollection<Client>(DataHandler.GetClients());

            clientFullNames = new List<string> { "GEEN CLIENT" };
            clientFullNames.AddRange(clients.Select(c => $"{ c.FirstName} { c.LastName}"));

            //Blackout Dates
            DateTime startDate = new DateTime(2023, 05, 01);
            DateTime endDate = new DateTime(2025, 12, 31);

            List<DateTime> blackoutDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Friday ||
                    date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday)
                {
                    blackoutDates.Add(date);
                }
            }

            foreach (DateTime date in blackoutDates)
            {
                AppointmentCalendar.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        private void AppointmentCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            if (AppointmentCalendar.SelectedDate.HasValue)
                    CurrentDateTextBlock.Text = AppointmentCalendar.SelectedDate.Value.ToString("d MMMM yyyy");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ListOfClients_Click(object sender, RoutedEventArgs e)
        {
            ClientOverview clientOverview = new();
            clientOverview.Show();
        }

        private void Consults_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Invoices_Click(object sender, RoutedEventArgs e)
        {
            InvoicesWindow invoicesWindow = new InvoicesWindow();
            invoicesWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
