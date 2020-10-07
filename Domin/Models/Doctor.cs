using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Doctor: DbObject   
    {
      
        [StringLength(50)]
        public String DoctorName { get; set; }
        
    }
}
