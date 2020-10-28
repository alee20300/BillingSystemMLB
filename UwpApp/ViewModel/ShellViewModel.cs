using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UwpApp.ViewModel
{
    public class ShellViewModel : BindableBase, IEditableObject

    {

        public PatientViewModel patientViewModel { get; set; }
        public ShellViewModel()
        {
            //SelectedPatientMemos = new ObservableCollection<Memo>();
            //Task.Run(GetPatientsListAsync);
            //Patient = new Patient();
            //this.PropertyChanged += ShellViewModel_PropertyChanged;
        }

        //private void ShellViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{

        //    var shell = (ShellViewModel)sender;
        //    this.SelectedPatientMemos.Clear();
        //    if (SelectedPatient is null)   return;
        //    if (SelectedPatient.Memos is null) return;
        //    foreach (var item in shell.SelectedPatient?.Memos)
        //    {
        //        SelectedPatientMemos.Add(item);
        //    }
        //}

        public ObservableCollection<Memo> SelectedPatientMemos { get; set; }

        public List<Patient> MasterPatientList { get; } = new List<Patient>();
        public ObservableCollection<Patient> PatientSuggestion { get; } = new ObservableCollection<Patient>();


        public async void LoadPatients()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;

                MasterPatientList.Clear();
            });

            var patients = await Task.Run(App.Repository.Patient.GetAsync);

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var patient in patients)
                {

                    MasterPatientList.Add(patient);
                }

                IsLoading = false;
            });
        }
        public  void updatepstientSuggestion(string idcard)
        {
            string[] parameters = idcard.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
            var resultlist = MasterPatientList
                 .Where(patient => parameters.Any(Parameter =>
                   patient.IdCardNumber.StartsWith(Parameter, StringComparison.OrdinalIgnoreCase)));
            //.Select
            //(patient => patient.IdCardNumber);

            foreach (var result in resultlist)
            {
                PatientSuggestion.Add(result);
            }
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

        //public async Task GetPatientsListAsync()
        //{
        //    await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);
        //    var patients = await App.Repository.Patient.GetAsync();
        //    if (patients == null)
        //    {
        //        return;
        //    }
        //    await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
        //    {
        //        Patients.Clear();
        //        foreach (var p in patients)
        //        {
        //            Patients.Add(new PatientViewModel(p));

        //        }
        //        IsLoading = false;
        //    });


        //}







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
