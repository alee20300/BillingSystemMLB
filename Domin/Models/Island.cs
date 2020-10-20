using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Island
    {
        public int Id { get; set; }
        public Atoll Atoll { get; set; }
        [StringLength(20)]
        public string IslandName { get; set; }
    }
}
