﻿using Domin.Data;
using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UwpApp.ViewModel.SettingsViewModelfolder;

namespace UwpApp.ViewModel
{
    public class MemoViewModel : BindableBase
    {
        public Memo Memo { get; set; }
        public MemoViewModel(Memo memo)
        {
            Memo = memo;
            MemoDetails = new ObservableCollection<MemoDetail>(Memo.MemoDetails);
            PaymentTypes = new ObservableCollection<PaymentType>();
            Accounts=  new ObservableCollection<AccountViewModel>();
            calcualteAge(Patient.DateOfBirth);
            Task.Run(LoadAccounts);
        }



        public ObservableCollection<AccountViewModel> Accounts { get; set; }
     

        public async Task LoadAccounts()
        {

            var result = App.AtollIslandViewModel.Accounts;
            foreach (var r in result)
            {
                Accounts.Add(r);
            }

        }

        public void AddPaymentType(AccountViewModel account) 
     {
            var Acc = account.Account;
           PaymentType acccunt = new PaymentType();
            acccunt.Account = Acc;
            acccunt.AccountName = Acc.AccountName;

           
            PaymentTypes.Add(acccunt);

        }

        public PaymentType PaymentType { get; set; }

        public ObservableCollection<PaymentType> PaymentTypes { get; set; } = new ObservableCollection<PaymentType>();

        public async static Task<MemoViewModel> CreatefromMemoId(int MemoId) =>
            new MemoViewModel(await GetMemo(MemoId));

        private static async Task<Memo> GetMemo(int MemoId) =>
            await App.Repository.Memo.GetbyIdAsync(MemoId);

        private MemoDetailViewModel _newMemoDetail;

        public MemoDetailViewModel NewMemoDetail
        {
            get => _newMemoDetail;
            set
            {
                if (value != _newMemoDetail)
                {
                    if (value != null)
                    {
                        value.PropertyChanged += NewMemoDetail_PropertyChanged;
                        //NewMemoDetail.account(1, 2);

                    }
                    if (_newMemoDetail != null)
                    {
                        _newMemoDetail.PropertyChanged -= NewMemoDetail_PropertyChanged;
                    }

                    _newMemoDetail = value;
                    UpdateNewMemoDetailBindings();
                   
                }

            }
        }

        private void NewMemoDetail_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateNewMemoDetailBindings();
        private void UpdateNewMemoDetailBindings()
        {
            OnPropertyChanged(nameof(NewMemoDetail));
            //OnPropertyChanged(nameof(AccountAmmount));
            //OnPropertyChanged(nameof(PatientAmmount));
            //OnPropertyChanged(nameof(HasNewMemoDetailItem));
            //OnPropertyChanged(nameof(NewMemoDtail))
        }


        public bool HasNewMemoDetailItem => NewMemoDetail != null && NewMemoDetail.Service != null;


      


        public Patient Patient
        {
            get => Memo.Patient;
            set
            {
                if (Memo.Patient != value)
                {

                    Memo.Patient = value;
                    OnPropertyChanged();
                    

                }
            }
        }

     


        public int Age { get; set; }

        public int Month { get; set; }
        public int Day { get; set; }

   

        public void calcualteAge(DateTime
            Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }

            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;

            Age = Years;
            Month = Months;
            Day = Days;
            OnPropertyChanged(nameof(Agestring));

        }



        public string Agestring
        {
            get => $"{Age}Year {Month} Month {Day} Day";



        }
        public DateTime COllectedDate
        {
            get => Memo.COllectedDate;
            set
            {
                if (Memo.COllectedDate != value)
                {
                    Memo.COllectedDate = value;
                    OnPropertyChanged();

                }
            }
        }


        //public string ReferanceCode
        //{
        //    get => Memo.ReferaceNo;
        //    set
        //    {

        //        if (Memo.ReferaceNo != value)
        //        {
        //            Memo.ReferaceNo = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}




        //private bool _ispaid;

        //public bool Ispaid
        //{
        //    get => _ispaid;
        //    set
        //    {
        //        if (_ispaid != value)
        //        {
        //            Ispaid = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}




        //public int CollectionSiteId
        //{
        //    get => Memo.CollectionSiteId;
        //    set
        //    {
        //        if (Memo.CollectionSiteId != value)
        //        {
        //            Memo.CollectionSiteId = value;
        //            OnPropertyChanged();

        //        }
        //    }
        //}

        public bool IsNewOrder => Memo.MemoId == 0;


        public bool IsLoaded => Memo != null && (IsNewOrder || Memo.Patient != null);

        public bool IsNotLoaded => !IsLoaded;

        bool _IsModified = false;
        public bool IsModified
        {
            get => _IsModified;
            set
            {
                if (value != _IsModified)
                {
                    // Only record changes after the order has loaded. 
                    if (IsLoaded)
                    {
                        _IsModified = value;
                        OnPropertyChanged();
                    }
                }
            }
        }
        private ObservableCollection<MemoDetail> _memoDetails;


        public ObservableCollection<MemoDetail> MemoDetails
        {
            get => _memoDetails;
            set
            {

                if (_memoDetails != value)
                {
                    if (value != null)
                    {
                        value.CollectionChanged += MemoDetails_Changed;
                    }
                    if (_memoDetails != null)
                    {
                        _memoDetails.CollectionChanged -= MemoDetails_Changed;

                    }
                    _memoDetails = value;
                    OnPropertyChanged();

                }
            }
        }



        private void MemoDetails_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (MemoDetails != null)
            {
                Memo.MemoDetails = MemoDetails.ToList();
            }

            //OnPropertyChanged(nameof(PatientTotal));
            //OnPropertyChanged(nameof(AccountAmmount));
            OnPropertyChanged(nameof(Rate));
            //OnPropertyChanged(nameof(Tax));
            //OnPropertyChanged(nameof(GrandTotal));
            IsModified = true;
        }


        public int MemoNumber
        {
            get => Memo.MemoId;

            set
            {
                if (value != Memo.MemoId)
                {
                    Memo.MemoId = value;
                    OnPropertyChanged();
                }
            }
        }

        //public void NewMemoDetail_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateNewMemoDetailBindings();
        public DateTime dateTime
        {
            get => Memo.MemoDate;
            set
            {
                if (value != Memo.MemoDate)
                {
                    Memo.MemoDate = value;
                    OnPropertyChanged();

                };
            }

        }
        //public DateTime CreatedOn
        //{
        //    get => Memo.CreatatedOn;
        //    set
        //    {
        //        if (value != Memo.CreatatedOn
        //            )
        //        {
        //            Memo.CreatatedOn = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //public Decimal PatientTotal
        //{
        //    get
        //    {
        //        return MemoDetails.Sum(m => m.PatientAmmount);
        //    }
        //    set
        //    {
        //        if (value != Memo.PatientAmmount)
        //        {
        //            Memo.PatientAmmount = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}


        //public Decimal AccountAmmount
        //{

        //    get
        //    {
        //        return MemoDetails.Sum(MemoDetails => MemoDetails.PaymentDetails.Sum(PaymentDetail => PaymentDetail.Amount));
        //    }
        //}

        public void updateprice()
        {
            //newAccountPrice = NewMemoDetail.MemoDetail.PaymentDetails.Sum(s => s.Amount);
            
            OnPropertyChanged(nameof(AccountAmmount));
            OnPropertyChanged(nameof(PatientAmmount));

        }


        public decimal newAccountPrice { get; set; }

        public Decimal AccountAmmount
        {
            get
            {

                return MemoDetails.Sum(MemoDetails => MemoDetails.PaymentDetails.Sum(PaymentDetail => PaymentDetail.Amount));
            }
            set
            {

                 
               
         
            }

        }

        public decimal PatientAmmount
        {
            get
            {
               

                return  MemoDetails.Sum(MemoDetails => MemoDetails.PaymentDetails.Sum(PaymentDetail => PaymentDetail.Amount-Rate));
            }

        }


        public decimal Rate
        {
            get
            {
                return MemoDetails.Sum(MemoDetails => MemoDetails.Rate);
            }

            set
            {
                if (value != Memo.Rate)

                {
                    Rate = MemoDetails.Sum(MemoDetails => MemoDetails.Rate);
                    OnPropertyChanged();

                }
            }
        }

        public string Address
        {
            get => Memo.Address;
            set
            {
                if (Memo.Address != value)

                {

                    Memo.Address = value;
                    OnPropertyChanged();

                }
            }
        }

        public string PatientName
        {
            get => Memo.PatientName;
            set
            {
                if (Memo.PatientName != value)
                {
                    Memo.PatientName = value;
                    OnPropertyChanged();

                }
            }
        }


        public Account Account
        {
            get => Account;
            set
            {
                if (value != Account)
                {
                   Account = value;
                    OnPropertyChanged();
                    

                }
            }
        }


        //public int AccountId
        //{
        //    get => Memo.AccountId;

        //    set
        //    {
        //        if (Memo.AccountId != value)
        //        {
        //            Memo.AccountId = value;
        //        }
        //    }
        //}

        //public Doctor Doctor
        //{
        //    get => Memo.Doctor;
        //    set
        //    {
        //        if (Memo.Doctor != value)
        //        {
        //           Memo. Doctor = value;
        //            OnPropertyChanged();

        //        }

        //    }
        //}



        public int DoctorID
        {
            get => Memo.DoctorId;
            set
            {
                if (value != Memo.DoctorId)
                {
                    Memo.DoctorId = value;
                    
                    OnPropertyChanged();

                }
            }
        }






        public async Task SaveMemoAsync()
        {



            //Task.Run(() => loadAccount("CASH"));

            Memo result = null;
            try
            {

                result = await App.Repository.Memo.UpsertAsync(Memo);
            }
            catch (Exception ex)
            {
                throw new MemoSavingException("Unable to Save Memo. There might have been a problem Connecting to Database. Please Try again later", ex);
            }
            if (result != null)
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsModified = false);

            }
        }

        public ObservableCollection<Service> ServiceSuggections { get; } = new ObservableCollection<Service>();


        public async void UpdateServiceSuggestions(string queryText)
        {
            ServiceSuggections.Clear();

            if (!string.IsNullOrEmpty(queryText))
            {
                var services = await App.Repository.Service.GetServiceAsync(queryText);

                foreach (Service service in services)
                {
                    ServiceSuggections.Add(service);
                }
            }
        }

    }


}
