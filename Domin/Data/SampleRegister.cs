using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
   public class SampleRegister
    {
        public int ReisterId { get; set; }
        public string SampleNumber { get; set; }
        public DateTime CollectedDate { get; set; }
        public DateTime RecivedDate { get; set; }
        public string RecivedBy { get; set; }
        public status Status { get; set; }
      
    }

    public enum status
    { 
        Registered,
        Processing,
        Processed,
        Completed,
        Dispatched,
        Issuedto

    }
}
