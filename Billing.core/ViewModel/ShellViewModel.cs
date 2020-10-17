using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Media;

namespace Billing.core.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        //public BillingRepository Repository { get; private set; }
        //public ObservableCollection<PatientViewModel> Patients { get; } = new ObservableCollection<PatientViewModel>();

     
        //public ShellViewModel()
        //{
        //    var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=reception\\SQLEXPRESS;Initial Catalog=Billing;User Id=sa;Password=sa@12345;");
        //    Repository = new BillingRepository(dbOptions);
           
        //}

       public void GetTask() 
        {
            
            Patient pt = new Patient
            {

                PatientNumber = "1112",
                Island = "Thinadhoo ",
                PermAddress = "Sandalwood",
                DateOfBirth = DateTime.Now,
                Atoll = "G Dh",
                Sex = "M",
                Country = "Maldives",
                Name = "ali abdulla",
                CreatatedOn = DateTime.UtcNow,
                CreatedBy = "Laith",


            };

            PatientSearched(pt);
        }

        private void PatientSearched(Patient e)
        {
            if (e is null) return;
            Name = e.Name;
            Address = $"{e.PermAddress}, {e.Atoll} {e.Island}";
            AgeSex = $"{CalculateAge(e.DateOfBirth)} / {e.Sex}";
            Contact = e.Contact;
            Email = e.Email;
        }

        public Patient Patient { get; set; }



        private string name;
        private string address;
        private string ageSex;
        private string contact;
        private string email;

        public ShellViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.name = "Ali Abdulla";
            }
        }

        private string CalculateAge(DateTime dateOfBirth)
        {
            //this is just for demo. Return the calculated age later
            return "13 Y";
            //throw new NotImplementedException(); 
        }

        #region Public Properties
        public string Name
        {
            get => name; set
            {
                Set(ref name, value);
            }
        }
        public string Address
        {
            get => address; set
            {
                Set(ref address, value);
            }
        }
        public string AgeSex
        {
            get => ageSex; set
            {
                Set(ref ageSex, value);
            }
        }
        public string Contact
        {
            get => contact; set
            {
                Set(ref contact, value);
            }
        }
        public string Email
        {
            get => email; set
            {
                Set(ref email, value);
            }
        }
        #endregion


    }
}
