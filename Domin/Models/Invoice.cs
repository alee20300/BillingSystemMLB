using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
   public class Invoice
    {
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }
        public bool IsCanceled { get; set; }
        [StringLength(1000)]
        public string CanceledReason { get; set; }
        public DateTime CanceledDate { get; set; }

        public decimal InvoiceAmmount { get; set; }


        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public List<Memo> Memos { get; set; }
        public List<InvoiceDetail> invoiceDetails { get; set; }

    }
}
