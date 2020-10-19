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
using Windows.UI.Xaml;

namespace UwpApp.ViewModel
{
    public class ShellViewModel : BindableBase , IEditableObject

    {
        
        public PatientViewModel patientViewModel  { get; set; }
        public ShellViewModel()
        {
            
            Task.Run(GetPatientsListAsync);
            
            
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

        

        private Patient _patient;

        public Patient Patient
        {
            get => _patient;
            set => Set(ref _patient, value);
        }

        

      

        public ObservableCollection<PatientViewModel> Patients { get; } = new ObservableCollection<PatientViewModel>();

        private PatientViewModel _selectedPatient;

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient; 
            set => Set(ref _selectedPatient, value);
        }

        public async Task GetPatientsListAsync()
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
