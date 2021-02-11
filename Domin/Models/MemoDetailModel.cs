using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
   public class MemoDetailModel
    {

        public MemoDetailModel()
        {

        }

        public int MemoDetailId { get; set; }
        public int Qty { get; set; }
        public Service Service { get; set; }

        public ICollection<PaymentDetailModel1> PaymentDetails { get; set; } = new List<PaymentDetailModel1>();
    }



}
