using System;
using System.Collections.Generic;

namespace Domin.Models
{
    public class Atoll
    {
        public int AtollId { get; set; }

        public String AtollName { get; set; }

        public ICollection<Island> Islands { get; set; } = new List<Island>();

    }
}
