using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
     public class MemoDetail :DbObject
    {
        public Memo Memo { get; set; }
        public Service Service { get; set; }
        public decimal Rate { get; set; }
        public int Qty { get; set; }
        public decimal PatientAmmount { get; set; }
        public decimal AccountAmmount { get; set; }
        public decimal AccountAmmount1 { get; set; }

        public Account Account { get; set; }

        public Account Account1 { get; set; }




    }
}
