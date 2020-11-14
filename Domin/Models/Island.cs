using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
    public class Island
    {
        public int Id { get; set; }
        [ForeignKey("AtollId")]
        public Atoll Atoll { get; set; }
        [StringLength(20)]
        public string IslandName { get; set; }
        public int AtollId { get; set; }

        public List<Patient> patients { get; set; } = new List<Patient>();
    }
}
