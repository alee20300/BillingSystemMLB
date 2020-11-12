using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Domin.Models
{
     public class MemoDetail :DbObject
    {
        public Memo Memo { get; set; }
        public Service Service { get; set; }
        public decimal Rate => Service.AccountServicePrices.FirstOrDefault(a => a.Account.Id == Account.Id).Rate;
        public int Qty { get; set; } = 1;
        public decimal PatientAmmount => Rate - AccountAmmount;
        public decimal AccountAmmount { get; set; }
        public decimal AccountAmmount1 { get; set; }

        public Account Account { get; set; } 

        public Account Account1 { get; set; }

        

        


    }
}
