using System;
using System.ComponentModel.DataAnnotations;

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
