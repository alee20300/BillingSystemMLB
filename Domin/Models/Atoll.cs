using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Models
{
    public class Atoll
    {
        public int AtollId { get; set; }
   
        public String AtollName { get; set; }

        public ICollection<Island> Islands { get; set; } = new List<Island>();

    }
}
                               