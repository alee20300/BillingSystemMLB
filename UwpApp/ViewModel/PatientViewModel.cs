using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using UwpApp.Validation;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel
{
    public class PatientViewModel : ValidatableBindableBase
    {
        public SaveCommand SaveCommand { get; set; }


        public PatientViewModel(Patient patient = null)
        {
            Patient = patient ?? new Patient();
            PatientValidation = new PatientValidation();
            SaveCommand = new SaveCommand(this);
            Task.Run(LoadMemoAsync);


        }


        public PatientValidation PatientValidation { get; set; }

        private void Memos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("SelectedPatientMemo");
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
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    RefreshMemos();

                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public int Id
        {
            get => Patient.PatientId;
            set
            {
                if (value != Patient.PatientId)

                {
                    Patient.PatientId = value;
                    IsModified = true;
                    OnPropertyChanged();
                };
            }
        }

        public string Name
        {
            get => Patient.PatientName;
            set
            {
                if (value != Patient.PatientName)
                {
                    Patient.PatientName = value;
                    IsModified = true;
                    OnPropertyChanged();
                    validate();

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

        public int CountryId
        {
            get => Patient.CountryId;
            set
            {
                if (value != Patient.CountryId)
                {
                    Patient.CountryId = value;
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


        public Country Country
        {
            get => Patient.country;
            set
            {
                if (value != Patient.country)
                {
                    Patient.country = value;
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

        public string IdCardNumber
        {
            get => Patient.IdCardNumber;
            set
            {
                if (value != Patient.IdCardNumber)
                {
                    Patient.IdCardNumber = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public int Atoll
        {
            get => Patient.AtollId;
            set
            {
                if (value != Patient.AtollId)
                {
                    Patient.AtollId = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }

        public int IslandId
        {
            get => Patient.IslandId;
            set
            {
                if (value != Patient.IslandId)
                {
                    Patient.IslandId = value;
                    IsModified = true;
                    OnPropertyChanged();

                }
            }
        }



        public Island Island
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
                    //calcualteAge(Patient.DateOfBirth);

                }
            }
        }

        //public string PatientNumber
        //{
        //    get => Patient.PatientNumber;
        //    set
        //    {
        //        if (value != Patient.PatientNumber)
        //        {
        //            Patient.PatientNumber = value;
        //            IsModified = true;
        //            OnPropertyChanged();

        //        }
        //    }
        //}

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

        public int Age { get; set; }

        public int Month { get; set; }
        public int Day { get; set; }

        public bool IsModified { get; set; }

        //public void calcualteAge(DateTime? Dob)
        //{
        //    DateTime Now = DateTime.Now;
        //    int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        //    DateTime PastYearDate = Dob.AddYears(Years);
        //    int Months = 0;
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        if (PastYearDate.AddMonths(i) == Now)
        //        {
        //            Months = i;
        //            break;
        //        }
        //        else if (PastYearDate.AddMonths(i) >= Now)
        //        {
        //            Months = i - 1;
        //            break;
        //        }
        //    }

        //    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;

        //    Age = Years;
        //    Month = Months;
        //    Day = Days;

        //}

        public ObservableCollection<Memo> Memos { get; } = new ObservableCollection<Memo>();

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

        public async Task RefreshPatientAsync()
        {
            RefreshMemos();
            Patient = await App.Repository.Patient.GetbyIdAsync(Patient.PatientId);
        }

        public void RefreshMemos()
        {
            Task.Run(LoadMemoAsync);
        }

        public async Task LoadMemoAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Isloading = true;
            });
            var memos = await App.Repository.Memo.GetForPatientAsync(Patient.PatientId);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Memos.Clear();
                foreach (var memo in memos)
                {
                    Memos.Add(memo);
                }
                Isloading = false;
            });
        }

        public void validate()
       {

            var result = PatientValidation.Validate(this);
            foreach (var error in result.Errors)
            {
                SetError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
