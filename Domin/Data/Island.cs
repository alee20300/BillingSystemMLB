using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
    public class Island
    {
        public int IslandId { get; set; }
        [ForeignKey("AtollId")]
        public Atoll Atoll { get; set; }
        
        public string IslandName { get; set; }
        public int AtollId { get; set; }

        public ICollection<Patient> patients { get; set; } = new List<Patient>();
    }
}
