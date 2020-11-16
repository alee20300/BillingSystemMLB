using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Models
{
   public class Catogory
    {
        public int CatogoryId { get; set; }
        public string CatogoryName { get; set; }

        public string CatogoryCode { get; set; }
        public ICollection<Service> Services { get; set; } = new List<Service>();


    }
}
