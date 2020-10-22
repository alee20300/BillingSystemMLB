using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            PatientName = patient.Name;
            Address = patient.PermAddress;


        }


        public String MemoNumber { get; set; }
        public DateTime MemoDate { get; set; }
        public Patient Patient { get; set; }

        [StringLength(100)]
        public string  PatientName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        public Doctor RequstedDoctor { get; set; }
        public decimal Rate { get; set; }

        public decimal Subtotal => MemoDetails.Sum(MemoDetail => MemoDetail.Rate * MemoDetail.Qty);
        public Account Account { get; set; }
        public Account Account1 { get; set; }
        public decimal PatientAmmount { get; set; }
        public decimal AccountAmmount { get; set; }
        public decimal  Account2Ammount { get; set; }

        public List<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();




    }
}
