using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace AppointFirstTryWPF.Model
{
    internal class DataHandler
    {
        #region Filepaths
        private const string CLIENTDATABASE = @"C:\Users\rheye\source\repos\WPF\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Cliënten.json";
        readonly static string clientFilePath = CLIENTDATABASE;
        static List<Client> clients;

        private const string INVOICEDATABASE = @"C:\Users\rheye\source\repos\WPF\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Rekeningen.JSON";
        readonly static string invoiceFilePath = INVOICEDATABASE;
        static List<Invoice> invoices;
        #endregion

        #region ClientList methods
        public static List<Client> GetClients()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd/MM/yyyyThh:mm:ss.000z";
            jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            if (!File.Exists(clientFilePath))
            {
                Console.WriteLine($"{clientFilePath} not found.");
            }

            var json = File.ReadAllText(clientFilePath);
            return JsonConvert.DeserializeObject<List<Client>>(json, jsonSettings);
        }

        public static void SaveClients(List<Client> clients)
        {
            var json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            if (File.Exists(clientFilePath))
                File.Delete(clientFilePath);

            File.WriteAllText(clientFilePath, json);
        }
        #endregion

        #region InvoiceList methods
        public static List<Invoice> GetInvoices()
        {
            if (!File.Exists (invoiceFilePath))
            {
                Console.WriteLine($"{invoiceFilePath} not found.");
            }

            var json = File.ReadAllText(invoiceFilePath);
            return JsonConvert.DeserializeObject<List<Invoice>>(json);
        }

        public static void SaveInvoices(List<Invoice> invoices)
        {
            var json = JsonConvert.SerializeObject(invoices, Formatting.Indented);

            if (File.Exists(invoiceFilePath))
                File.Delete(invoiceFilePath);

            File.WriteAllText (invoiceFilePath, json);
        }
        #endregion
    }
}
