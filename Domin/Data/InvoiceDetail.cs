using System.Collections.Generic;

namespace Domin.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public List<MemoDetail> MemoDetail { get; set; }
        public decimal MemoAmmount { get; set; }
    }
}
