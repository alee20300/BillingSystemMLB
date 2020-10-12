using Domin.Models;
using Microsoft.EntityFrameworkCore;
using MvvmCross.ViewModels;
using Repository;
using System;
using System.Collections.ObjectModel;

namespace Billing.core.ViewModel
{
    public class PatientViewModel : MvxViewModel

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
                CreatedBy="Laith",


            };
            _patients.Add(pt);

            Repository.Patient.UpsertAsync(pt);

        }





        public static IBillingRepository Repository { get; private set; }

        public PatientViewModel(Patient patient)
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=reception\\SQLEXPRESS;Initial Catalog=Billing;User Id=sa;Password=sa@12345;");
            Repository = new BillingRepository(dbOptions);
            //addpatient();
            Patient = patient ?? new Patient();


        }



        public ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();

        public ObservableCollection<Patient> Patients
        {
            get => _patients;

            set { SetProperty(ref _patients, value); }
        }

        private async void GetPatientAsync()
        {
            var patients = await Repository.Patient.GetAsync();
            Patients.Clear();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }

        }

        private Patient _patient;

        public Patient Patient
        {
            get => _patient;
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    //Task.Run(GetPatientAsync);
                }


            }

        }


        private string _name;

        public string Name
        {
            get => Patient.Name;
            set { SetProperty(ref _name, value); }
        }


        private string _permAddress;

        public string PermAddress
        {
            get { return _permAddress; }
            set { SetProperty(ref _permAddress, value); }
        }

        private string _patientNumber;

        public string PatientNumber
        {
            get { return _patientNumber; }
            set { SetProperty(ref _patientNumber, value); }
        }

        private string _atoll;

        public string Atoll
        {
            get { return _atoll; }
            set { SetProperty(ref _atoll, value); }
        }

        private DateTime _dateofb;

        public DateTime DateOfBirth
        {
            get { return _dateofb; }
            set { SetProperty(ref _dateofb, value); }
        }


        private string _island;

        public string Island
        {
            get { return _island; }
            set { SetProperty(ref _island, value); }
        }



    }
}
