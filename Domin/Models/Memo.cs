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
            PatientName = patient.Name;
            Address = patient.PermAddress;
            

        }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int AccountId { get; set; }
        public int MemoNumber { get; set; }
        public DateTime MemoDate { get; set; }
     [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }

        [StringLength(100)]
        public string  PatientName { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    
        public decimal Rate => MemoDetails.Sum(MemoDetail => MemoDetail.Rate * MemoDetail.Qty);
    
        
        public decimal PatientAmmount => MemoDetails.Sum(MemoDetails => MemoDetails.PatientAmmount * MemoDetails.Qty);

        public decimal AccountAmmount => MemoDetails.Sum(MemoDetails => MemoDetails.AccountAmmount * MemoDetails.Qty);


      

        public List<MemoDetail> MemoDetails { get; set; } = new List<MemoDetail>();




    }
}
