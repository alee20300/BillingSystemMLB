﻿using Domin.Models;

namespace UwpApp.ViewModel
{
    public class InvoiceDetailViewModel
    {
        public InvoiceDetailViewModel(object obj)
        {
            
        }

        public InvoiceDetail InvoiceDetail { get; set; }




        public int InvoiceDetailId { get; set; }

        public decimal MemoAmount { get; set; }


        public bool Isadded { get; set; }

    }
}
