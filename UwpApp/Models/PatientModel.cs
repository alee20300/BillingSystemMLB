using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel;

namespace UwpApp.Models
{
    public class PatientModel : ValidatableBindableBase

    {

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
        public ICollection<Memo> Memos { get; set; } = new List<Memo>();

    }
}
