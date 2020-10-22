using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Domin.Models
{
    public class Service
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string ServiceCode { get; set; }


        [StringLength(50)]
        public string ServiceName { get; set; }


        public Catogory Catogory { get; set; }


        [StringLength(10)]
        public string ICode { get; set; }

        [StringLength(10)]
        public String LisCode { get; set; }

        public decimal Rate { get; set; }

        public bool IsActive { get; set; }
        
    }
}
