using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domin.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
      
        public String DoctorName { get; set; }
        public ICollection<Memo> Memos { get; set; } = new List<Memo>();

    }
}
