using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domin.Models
{
   
    public class Memo :AuditEntity
    {
        public String MemoNumber { get; set; }
        public DateTime MemoDate { get; set; }
        public Patient Patient { get; set; }
        public Doctor RequstedDoctor { get; set; }
        public decimal Rate { get; set; }
        public int Qty { get; set; }
        public Account Account { get; set; }
        public Account Account1 { get; set; }
        public decimal PatientAmmount { get; set; }
        public decimal AccountAmmount { get; set; }
        public decimal  Account2Ammount { get; set; }



    }
}
