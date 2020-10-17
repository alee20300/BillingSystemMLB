using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Domin.Models;
using Windows.UI.Xaml.Media;

namespace UwpApp.ViewModel
{
    public class PatientViewModel :BindableBase
    {
        public PatientViewModel(Patient p)
        {
            Patient = new Patient();
            Patient.Name = p.Name;
            Patient.PermAddress = p.PermAddress;
            Patient.PatientNumber = p.PatientNumber;
            Patient.Island = p.Island;
            Patient.LastModifeid = p.LastModifeid;
            Patient.LastModifiedBy = p.LastModifiedBy;
            Patient.Sex = p.Sex;
        }


       
        private bool IsLoading = false;

        public bool MyProperty
        {
            get { return IsLoading; }
            set { Set(ref IsLoading, value); }
        }

        private Patient _patient;

        public Patient Patient
        {
            get { return _patient; }
            set { Set(ref _patient, value); }
        }

        


    }
}
