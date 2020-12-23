using Domin.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Domin.Models
{
   
    public class Memo :AuditEntity
    {

        public Memo()
        {

        }

        public Memo(Patient patient)
            :this()
        {
            Patient = patient;
            PatientId = patient.PatientId;
            PatientName = patient.PatientName;
            Address = patient.PermAddress;
            

        }

        public int MemoId { get; set; }
        public DateTime MemoDate { get; set; }

        public string  PatientName { get;  set; }

        public string Address { get;  set; }


        public DateTime COllectedDate { get; set; }

        

        public decimal Rate { get; set; }
    
        public decimal PatientAmmount { get; set; }

        public decimal AccountAmmount { get; set; }

        public int CollectionSiteId { get; set; }

        public bool IsPaid { get; set; }


        public PaymentType PaymentSign { get; set; }


        public ICollection<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();



        #region Navigation
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }

        public Memo Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        #endregion


    }
}
