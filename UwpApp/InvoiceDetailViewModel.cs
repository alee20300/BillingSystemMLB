using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel;

namespace UwpApp
{
   public class InvoiceDetailViewModel :BindableBase

    {

        public InvoiceDetailViewModel()
        {
                
        }

        public InvoiceDetail InvoiceDetail { get; set; }

        public int InvoiceDetailId { get; set; }
        public decimal MemoAmmount { get; set; }
        public int InvoiceId { get; set; }


    }
}
