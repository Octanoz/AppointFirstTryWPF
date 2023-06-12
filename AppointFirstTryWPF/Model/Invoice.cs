using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointFirstTryWPF.Model
{
    public class Invoice
    {
        public int invoice_number { get; set; }
        public string invoice_date { get; set; }
        public decimal amount { get; set; }
        public int client_id { get; set; }
    }
}
