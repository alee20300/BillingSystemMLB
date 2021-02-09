using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
     public class TestProfiles
    {
        public int TestProfileID { get; set; }
        public String ProfileName { get; set; }
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
