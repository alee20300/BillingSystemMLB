using Domin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Models
{
    public class Patient : AuditEntity

    {
        public int PatientId { get;  set; }

        public Patient()
        {

        }
        public Patient(SampleRegister sampleRegister)
           : this()
        {
            PatientName = sampleRegister.SampleNumber;
            IdCardNumber = sampleRegister.SampleNumber;
            PermAddress = "C/O National Drug Agency";
            Sex = "U";
            DateOfBirth = DateTime.Now;
            Contact = "0";
            AtollId = 1;
            IslandId = 1;
            CountryId = 1;

        }
       


        public string PatientName { get; set; }

        public string IdCardNumber { get; set; }

        public string PermAddress { get; set; }

        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Contact { get; set; }


        public string Email { get; set; }


        public int AtollId { get; set; }

        public int IslandId { get; set; }
        [ForeignKey("IslandId")]
        public Island Island { get; set; }
        [StringLength(50)]

        [ForeignKey("CountryId")]
        public Country country { get; set; }

        public int CountryId { get; set; }
        public ICollection<Memo> Memos { get; set; } = new List<Memo>();

       
    }


}
