using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{


    public  class PaymentDetail
    {
        public int PaymentId { get; set; }
        public MemoDetail MemoDetail { get; set; }
        public Account Account { get; set; }

        public Decimal Amount { get; set; }
        public PaymentStatus  PaymentStatus { get; set; }

    }
}
