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

        private const string CONSULTDATABASE = @"C:\Users\rheye\source\repos\WPF\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Consult.cs";
        readonly static string consultFilePath = CONSULTDATABASE;
        static List<Consult> consults;
        #endregion

        #region ClientList methods
        public static List<Client> GetClients()
        {
            return ReadFromJsonFile<List<Client>>(clientFilePath, GetClientJsonSettings());
        }

        public static void SaveClients(List<Client> clients)
        {
            SaveToJsonFile(clients, clientFilePath);
        }
        #endregion

        #region InvoiceList methods
        public static List<Invoice> GetInvoices()
        {
            return ReadFromJsonFile<List<Invoice>>(invoiceFilePath);
        }

        public static void SaveInvoices(List<Invoice> invoices)
        {
            SaveToJsonFile(invoices, invoiceFilePath);
        }
        #endregion

        public static List<Consult> GetConsults()
        {
            return ReadFromJsonFile<List<Consult>>(consultFilePath);
        }

        private static T ReadFromJsonFile<T>(string filePath, JsonSerializerSettings settings = null)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} not found.");
                return default(T);
            }

            var json = File.ReadAllText (filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static void SaveToJsonFile<T>(T data, string filePath)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, json);
        }

        private static JsonSerializerSettings GetClientJsonSettings()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd/MM/yyyyThh:mm:ss.000z";
            jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            return jsonSettings;
        }
    }
}
