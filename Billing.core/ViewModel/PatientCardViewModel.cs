using Domin.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.core.ViewModel
{
    public class PatientCardViewModel : MvxViewModel
    {
        private string name;
        private string address;
        private string ageSex;
        private string contact;
        private string email;

        internal void PatientSearched(object sender, Patient e)
        {
            if (e is null) return;
            Name = e.Name;
            Address = $"{e.PermAddress}, {e.Atoll} {e.Island}";
            AgeSex = $"{CalculateAge(e.DateOfBirth)} / {e.Sex}";
            Contact = e.Contact;
            Email = e.Email;
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
                SetProperty(ref name, value);
            }
        }
        public string Address
        {
            get => address; set
            {
                SetProperty(ref address, value);
            }
        }
        public string AgeSex
        {
            get => ageSex; set
            {
                SetProperty(ref ageSex, value);
            }
        }
        public string Contact
        {
            get => contact; set
            {
                SetProperty(ref contact, value);
            }
        }
        public string Email
        {
            get => email; set
            {
                SetProperty(ref email, value);
            }
        }
        #endregion



    }
}
