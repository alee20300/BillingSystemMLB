using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
   public class MemoDetailModel
    {
        public MemoDetailModel()
        {

        }

        public decimal Rate { get; set; }
        public int Qty { get; set; } = 1;
      


        public ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();


        public decimal accountprice()
        {
            return 2;
        }

        public Account accountModel { get; set; }

        public void makepayment()
        {
            PaymentDetail paymentDetail = new PaymentDetail();
            paymentDetail.Account = accountModel;
            paymentDetail.Amount = accountprice();


                
        }
    }
}
