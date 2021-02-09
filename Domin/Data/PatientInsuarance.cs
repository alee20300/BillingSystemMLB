using Domin.Models;
using System;

namespace Domin.Data
{
    public class PatientInsuarance
    {
        public int PatientInsuaranceId { get; set; }
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int InsaranceId { get; set; }
        public Insuarance Insuarance { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidThru { get; set; }
    }
}
