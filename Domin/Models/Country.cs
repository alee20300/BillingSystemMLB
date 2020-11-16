using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
   public class Country
    {
        public int CountryId { get; set; }
       
        public string CountryName { get; set; }
        public List<Patient> patients { get; set; }
    }
}
