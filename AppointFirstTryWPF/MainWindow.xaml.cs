using AppointFirstTryWPF.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AppointFirstTryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListOfClients_Click(object sender, RoutedEventArgs e)
        {
            //After changing the modalwindow constructor to take an owner window you will need to specify that owner in the initialization. so that's why we added (this).
            ClientOverview clientOverview = new ClientOverview(this);
            Opacity = 0.6;
            clientOverview.ShowDialog();
            Opacity = 1;
        }

        private void AppointmentCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (AppointmentCalendar.SelectedDate.HasValue)
                    DateTextBlock.Text = AppointmentCalendar.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                Debug.WriteLine(ex.ToString());
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
