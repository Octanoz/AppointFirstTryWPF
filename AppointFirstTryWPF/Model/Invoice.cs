using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointFirstTryWPF.Model
{
    public class Invoice
    {
        public int Invoice_Number { get; set; }
        public string Invoice_Date { get; set; }
        public decimal Amount { get; set; }
        public int Client_Id { get; set; }
    }
}
