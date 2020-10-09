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

        public void addpatient()
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
            //_patients.Add(pt);

            Repository.Patient.UpsertAsync(pt);

        }
        public MainViewModel()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=reception\\SQLEXPRESS;Initial Catalog=Billing;User Id=sa;Password=sa@12345;");
          Repository = new BillingRepository(dbOptions);
            //addpatient();
                Task.Run(GetPatientListAsync);

            
        }

        private string _name;

        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
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
