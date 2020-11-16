using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
     public class AccountServicePrice :AuditEntity
    {

        public int AccountServicePriceId { get; set; }
        [ForeignKey("Account_Id")]

        public Account Account { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public decimal Rate { get; set; }
        public decimal PatientAmmount { get; set; }
        public decimal AccountAmmount { get; set; }

       
    }
}
