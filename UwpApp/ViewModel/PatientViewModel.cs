using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Domin.Models;
using Windows.UI.Xaml.Media;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel
{
    public class PatientViewModel :BindableBase
    {
        public SaveCommand  SaveCommand { get; set; }
        public PatientViewModel(Patient patient =null)
        {
          
            Patient = patient ?? new Patient();

            SaveCommand = new SaveCommand(this);
        }

      
        private bool _IsLoading = false;

        public bool Isloading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }



        private Patient _patient;

        public Patient Patient
        {
            get => _patient;
            set {
                if (_patient!=value)
                {
                    _patient = value;

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public string Name {
            get=>Patient.Name;
            set
            {
                if (value!=Patient.Name)
                {
                    Patient.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                    
                }
            }
        }

        public string PermAddress
        {
            get => Patient.PermAddress;
            set
            {
                if (value != Patient.PermAddress)
                {
                    Patient.PermAddress = value;
                    IsModified = true;
                    OnPropertyChanged();
                    
                }
            }
        }

        public string Contact
        {
            get => Patient.Contact;
            set
            {
                if (value != Patient.Contact)
                {
                    Patient.Contact = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }


        public string Email
        {
            get => Patient.Email;
            set
            {
                if (value != Patient.Email)
                {
                    Patient.Email = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }


        public string Coutry
        {
            get => Patient.Country;
            set
            {
                if (value != Patient.Country)
                {
                    Patient.Country = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string Sex
        {
            get => Patient.Sex;
            set
            {
                if (value != Patient.Sex)
                {
                    Patient.Sex = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string Atoll 
        {
            get => Patient.Atoll;
            set
            {
                if (value != Patient.Atoll)
                {
                    Patient.Atoll = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string Island
        {
            get => Patient.Island;
            set
            {
                if (value != Patient.Island)
                {
                    Patient.Island = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public DateTime DateOfBirth
        {
            get => Patient.DateOfBirth;
            set
            {
                if (value != Patient.DateOfBirth)
                {
                    Patient.DateOfBirth = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string PatientNumber
        {
            get => Patient.PatientNumber;
            set
            {
                if (value != Patient.PatientNumber)
                {
                    Patient.PatientNumber = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string CreatedBy
        {
            get => Patient.CreatedBy;
            set
            {
                if (value != Patient.CreatedBy)
                {
                    Patient.CreatedBy = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public DateTime CreatedOn 
        {
            get => Patient.CreatatedOn;
            set
            {
                if (value != Patient.CreatatedOn)
                {
                    Patient.CreatatedOn = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public DateTime LastModifiedOn
        {
            get => Patient.LastModifeid;
            set
            {
                if (value != Patient.LastModifeid)
                {
                    Patient.LastModifeid = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public string LastModifiedBy
        {
            get => Patient.LastModifiedBy;
            set
            {
                if (value != Patient.LastModifiedBy)
                {
                    Patient.LastModifiedBy = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public bool IsModified { get;  set; }

        public ObservableCollection<Memo> Memo
        { get; } = new ObservableCollection<Memo>();

        private Memo _selectedeMemo;

        public Memo SelectedMemo
        {
            get => _selectedeMemo;
            set => Set(ref _selectedeMemo, value);
        }

        private bool _isNewCustomer;

        public bool IsNewCustomer
        {
            get => _isNewCustomer;
            set => Set(ref _isNewCustomer, value);
        }


    }
}
