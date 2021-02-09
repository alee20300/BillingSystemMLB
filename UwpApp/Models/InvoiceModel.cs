using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
   public class InvoiceModel
    {

        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Today;
        public bool IsCanceled { get; set; } = false;

        public string CanceledReason { get; set; }
        public DateTime? CanceledDate { get; set; }

        public decimal InvoiceAmmount { get; set; }

    }
}
