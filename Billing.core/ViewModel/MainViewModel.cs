using Domin.Models;
using Microsoft.EntityFrameworkCore;
using MvvmCross.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Billing.core.ViewModel
{
   public class MainViewModel : MvxViewModel   
    {
        private PatientViewModel _patientViewModel;

        public PatientViewModel PatientViewModel
        {
            get => _patientViewModel;
            set { SetProperty(ref _patientViewModel, value); }
        }

        public void addpatient()
        {
            
            Patient pt = new Patient
            {

                PatientNumber = "1122",
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
         P1.Add(pt);

            //Repository.Patient.UpsertAsync(pt);

        }
        public MainViewModel()
        {
            //  var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=reception\\SQLEXPRESS;Initial Catalog=Billing;User Id=sa;Password=sa@12345;");
            //Repository = new BillingRepository(dbOptions);

            P1 = new ObservableCollection<Patient>();
            addpatient();
            //Task.Run(GetPatientListAsync);
           
           
            
        }

        private string _name;

        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        private ObservableCollection<Patient> _p1;      

        public ObservableCollection<Patient> P1
        {
            get { return _p1; }
            set { SetProperty(ref _p1, value); }
        }


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
