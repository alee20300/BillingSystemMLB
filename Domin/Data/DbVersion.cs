using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Data
{
    [Table("DbVersion")]
    public class DbVersion
    {
        [Key]
        public string Version { get; set; }
    }
}
