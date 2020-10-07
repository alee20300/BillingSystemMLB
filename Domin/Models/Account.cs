using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Account :AuditEntity

    {
        public int Id { get; set; }
        [StringLength(50)]
        public string AccountName { get; set; }
        [StringLength(10)]
        public string AccountCode { get; set; }
    }
}
