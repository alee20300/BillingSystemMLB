using Domin.Models;
using System;
using ViewModels.Infrastructure.ViewModels;

namespace ViewModels.Models
{
    public class PatientModel : ObservableObject

    {
        static public PatientModel CreateEmpty() => new PatientModel { PatientId = -1, IsEmpty = true };

        public int PatientId { get; set; }


        public string PatientName { get; set; }

        public string IdCardNumber { get; set; }

        public string PermAddress { get; set; }

        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Contact { get; set; }


        public string Email { get; set; }


        public int AtollId { get; set; }

        public int IslandId { get; set; }

        public Island Island { get; set; }


        public Country country { get; set; }

        public int CountryId { get; set; }

        public override string ToString()
        {
            return IsEmpty ? "Empty" : PatientName;
        }

    }
}
