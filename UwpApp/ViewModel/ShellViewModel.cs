using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Core;



namespace UwpApp.ViewModel
{
    public class ShellViewModel : BindableBase , IEditableObject

    {

        public PatientViewModel patientViewModel  { get; set; }
        public ShellViewModel()
        {
            Task.Run(GetPatientsAsync);
            
            NameF = "ali";
            Patient = new Patient();

            Patient.PatientNumber = "1112";
            Patient.Island = "Thinadhoo ";
            Patient.PermAddress = "Sanlwood";
            Patient.DateOfBirth = DateTime.Now;
            Patient.Atoll = "G Dh";
            Patient.Sex = "M";
            Patient.Country = "Maldives";
            Patient.Name = "ali Abdulla";
            Patient.CreatatedOn = DateTime.UtcNow;
            Patient.CreatedBy = "Laith";

           

        }

        public  async Task adddemodata()
        {
            Patient pt = new Patient
            {

                PatientNumber = "112",
                Island = "Thinadhoo ",
                PermAddress = "Sandalwood",
                DateOfBirth = DateTime.Now,
                Atoll = "G Dh",
                Sex = "M",
                Country = "Maldives",
                Name = "MOhamed Laith ali abdulla",
                CreatatedOn = DateTime.UtcNow,
                CreatedBy = "Laith",


            };

            await App.Repository.Patient.UpsertAsync(pt);
        }

        private Patient _patient;

        public Patient Patient
        {
            get => _patient;
            set => Set(ref _patient, value);
        }

        private string _nameF;

        public string NameF
        {
            get => _nameF;
            set => Set(ref _nameF, value);
        }


        public string Name
        {
            get => Patient.Name;
            set
            {
                if (value != Patient.Name)
                {
                    Patient.Name = value;
                    OnPropertyChanged();
                }
            }

        }

        public ObservableCollection<PatientViewModel> Patients { get; } = new ObservableCollection<PatientViewModel>();

        private PatientViewModel _selectedPatient;

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient; 
            set => Set(ref _selectedPatient, value);
        }

        private async Task GetPatientsAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);
            var patients = await App.Repository.Patient.GetAsync();
            if (patients==null)
            {
                return;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Patients.Clear();
                foreach (var p in patients)
                {
                    Patients.Add(new PatientViewModel(p));
                    
                }
                IsLoading = false;
            });
            

        }

        private int age=1;

        public int Age
        {
            get => age;
            set
            {
                Set(ref age, value);
                
            }

            
        }

        public void plus1()
        { /*Age = Age + age;*/
            NameF = "Name Changed";
            demodate();
            //adddemodata();
        }


        public void demodate()
        {
            Name = "Ali";
           
        }


        public void BeginEdit()
        {
            throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            throw new NotImplementedException();
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }


       
    }
}
