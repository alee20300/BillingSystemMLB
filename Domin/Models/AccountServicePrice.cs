using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
     public class AccountServicePrice :AuditEntity
    {

        public int Id { get; set; }
        public Account Account { get; set; }
        public Service Service { get; set; }
        public decimal Rate { get; set; }
        public decimal PatientAmmount { get; set; }
        public decimal AccountId { get; set; }
    }
}
