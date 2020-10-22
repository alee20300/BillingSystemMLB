using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Atoll
    {
        public int Id { get; set; }
        [StringLength(4)]
        public String AtollName { get; set; }
    }
}
