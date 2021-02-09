using System.Collections.Generic;

namespace Domin.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        public List<Patient> patients { get; set; }
    }
}
