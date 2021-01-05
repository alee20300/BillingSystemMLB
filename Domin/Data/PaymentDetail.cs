using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
    

  public  class PaymentDetail
    {
        public int PaymentId { get; set; }
        public Memo Memo { get; set; }
        public Account Account { get; set; }

        public Decimal Amount { get; set; }
        
    }
}
