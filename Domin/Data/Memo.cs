using Domin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Models
{

    public class Memo : AuditEntity
    {

        public Memo()
        {

        }

        public Memo(Patient patient)
            : this()
        {
            Patient = patient;
            PatientId = patient.PatientId;
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


        public ICollection<PaymentType> PaymentSign { get; set; } = new List<PaymentType>();


        public ICollection<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();



        #region Navigation
        //[ForeignKey("AccountId")]
        //public Account Account { get; set; }
        //public int AccountId { get; set; }

      

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        //[ForeignKey("DoctorId")]
        //public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        #endregion


    }
}
