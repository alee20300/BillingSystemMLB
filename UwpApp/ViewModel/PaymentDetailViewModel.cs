using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel
{
    public class PaymentDetailViewModel : BindableBase
    {
        private PaymentDetail paymentDetail;
        private Account account;
        private decimal ammount;

        public PaymentDetailViewModel(Decimal Amm, Account account)
        {

        }
        public PaymentDetail PaymentDetail { get => paymentDetail; set => paymentDetail = value; }
        public Account Account
        {
            get => PaymentDetail.Account;
            set
            {
                if (PaymentDetail.Account!=value)
                {
                    PaymentDetail.Account = value;
                }  }
        }
        public decimal Ammount

        {
            get => PaymentDetail.Amount;


            set
            {
                if (PaymentDetail.Amount!=value)
                {
                    PaymentDetail.Amount = value;
                } }
        }
    }
}
