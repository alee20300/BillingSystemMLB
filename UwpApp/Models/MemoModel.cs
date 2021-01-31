using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
   public class MemoModel
    {
        public MemoModel(Patient patient)
        {
            PatientName = patient.PatientName;
            Address = patient.PermAddress;

        }
        public int MemoId { get; set; }
        public DateTime MemoDate { get; set; }

        public string PatientName { get; set; }

        public string Address { get; set; }


        public DateTime COllectedDate { get; set; }


        public string ReferaceNo { get; set; }
        public decimal Rate { get; set; }

        //public decimal PatientAmmount { get; set; }

        //public decimal AccountAmmount { get; set; }

        //public int CollectionSiteId { get; set; }

        public bool IsPaid { get; set; }


        public void makeMakeMemodetail()
        {
            MemoDetailModel memoDetailModel = new MemoDetailModel();
            


        }


        //[ForeignKey("AccountId")]
        //public Account Account { get; set; }
        //public int AccountId { get; set; }




    }
}
