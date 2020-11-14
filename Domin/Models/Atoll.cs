using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
    public class Atoll
    {
        public int Id { get; set; }
        [StringLength(5)]
        [Column("Atoll_Name")]
        public String AtollName { get; set; }

        public List<Island> Islands { get; set; } = new List<Island>();

    }
}
                               