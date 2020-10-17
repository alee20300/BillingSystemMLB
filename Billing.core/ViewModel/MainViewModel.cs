using Domin.Models;
using Microsoft.EntityFrameworkCore;
using MvvmCross.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.core.ViewModel
{
   public class MainViewModel : MvxViewModel   
    {
        private PatientViewModel _patientViewModel;
        private PatientCardViewModel _patientCardViewModel;

        public event EventHandler<Patient> OnPatientSearch;
        public PatientViewModel PatientViewModel
        {
            get => _patientViewModel;
            set {SetProperty (ref _patientViewModel, value); }
        }

           

        public MainViewModel()
        {
            //  var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=reception\\SQLEXPRESS;Initial Catalog=Billing;User Id=sa;Password=sa@12345;");
            //Repository = new BillingRepository(dbOptions);
            _patientCardViewModel = new PatientCardViewModel();
            OnPatientSearch += _patientCardViewModel.PatientSearched;
            P1 = new ObservableCollection<Patient>();
            
            //Task.Run(GetPatientListAsync);

            OnPatientSearch?.Invoke(this, P1.FirstOrDefault());
            
        }

        private string _name;

        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }


        public ObservableCollection<Patient> P1 { get; private set; }

        public ObservableCollection<PatientViewModel> Patients { get; } = new ObservableCollection<PatientViewModel>();

        private PatientViewModel _selectedPatient;

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value); 
        }
        public BillingRepository Repository { get; }

        private async Task GetPatientListAsync()
        {
            var patient = await Repository.Patient.GetAsync();
            Patients.Clear();
             foreach (var p  in patient)
            {
                Patients.Add(new PatientViewModel(p));
            } 
        }
    }
}
