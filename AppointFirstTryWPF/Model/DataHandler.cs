using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointFirstTryWPF.Model
{
    internal class DataHandler
    {
        private const string CLIENTDATABASE = @"C:\Users\rheye\source\repos\WPF\WPF Training\AppointFirstTryWPF\AppointFirstTryWPF\Model\Cliënten.json";
        readonly static string filePath = CLIENTDATABASE;
        static List<Client> clients;

        public static List<Client> GetClients()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} not found.");
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Client>>(json);
        }

        public static void SaveClients(List<Client> clients)
        {
            var json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, json);
        }
    }
}
