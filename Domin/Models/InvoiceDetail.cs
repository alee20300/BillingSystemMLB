using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
     public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public List<MemoDetail> MemoDetail { get; set; }
        public decimal MemoAmmount { get; set; }
    }
}
