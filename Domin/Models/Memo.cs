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
        public decimal Rate => MemoDetails.Sum(MemoDetail => MemoDetail.Rate * MemoDetail.Qty);
        
        public Account Account { get; set; }
        public Account Account1 { get; set; }
        public decimal PatientAmmount => MemoDetails.Sum(MemoDetails => MemoDetails.PatientAmmount * MemoDetails.Qty);

        public decimal AccountAmmount => MemoDetails.Sum(MemoDetails => MemoDetails.AccountAmmount * MemoDetails.Qty);

        public decimal Account2Ammount  =>  MemoDetails.Sum(MemoDetails => MemoDetails.AccountAmmount1 * MemoDetails.Qty);


        public List<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();




    }
}
