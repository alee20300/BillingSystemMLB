using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
   public class AuditEntity
    {
        [StringLength(25)]
        public string CreatedBy { get; set; }
        public DateTime CreatatedOn { get; set; }
        [StringLength(25)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifeid { get; set; }
    }
}
