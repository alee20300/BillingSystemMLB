using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Printing;

namespace UwpApp.ViewModel
{
  public  class MemoViewModel :BindableBase
    {

        public Memo Memo { get; }
        public MemoViewModel(Memo memo)
        {
            Memo = memo;

            MemoDetails = new ObservableCollection<MemoDetail>(Memo.MemoDetails);


            NewMemoDetail = new MemoDetailViewModel();

            if (memo.Patient==null)
            {
                Task.Run(() => loadpatient(Memo.MemoNumber));
            }

            //addmemodatademo();
        }

    

        public async static Task<MemoViewModel> CreatefromMemoId(string MemoId) =>
            new MemoViewModel(await GetMemo(MemoId));

        private static async Task<Memo> GetMemo(string MemoId) =>
            await App.Repository.Memo.GetbyIdAsync(MemoId);

        private MemoDetailViewModel  _newMemoDetail;

        public MemoDetailViewModel  NewMemoDetail
        {
            get => _newMemoDetail;
            set {
                if (value!= _newMemoDetail)
                {
                    if (value!=null)
                    {
                        value.PropertyChanged += NewMemoDetail_PropertyChanged;
                    }
                    if (_newMemoDetail !=null)
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
            OnPropertyChanged(nameof(HasNewMemoDetailItem));
            //OnPropertyChanged(nameof(NewMemoDtail))
        }


        public bool HasNewMemoDetailItem => NewMemoDetail != null && NewMemoDetail.Service != null;


        private async void loadpatient(string memoNumber)
        {
            var patient = await App.Repository.Patient.GetbyIdAsync(memoNumber);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Patient = patient;
            });
        }

        public void addmemodatademo()
        
        {
            Memo m = new Memo();
            m.MemoNumber = "121212";
            m.MemoDate = DateTime.UtcNow;
            m.Patient.Id = "1";
            m.PatientName = "Ali Abdulla";
            m.Account.Id = 1;
            App.Repository.Memo.UpsertAsync(m);
        }
       
        public Patient Patient
        {
            get => Memo.Patient;
            set
            {
                if (Memo.Patient != value)
                {
                    var isLoadingOperation = Memo.Patient == null &&
                        value != null && !IsNewOrder;
                    Memo.Patient = value;
                    OnPropertyChanged();
                    if (isLoadingOperation)
                    {
                        OnPropertyChanged(nameof(IsLoaded));
                        OnPropertyChanged(nameof(IsNotLoaded));
                    }
                    else
                    {
                        IsModified = true;
                    }
                }
            }
        }



        public bool IsNewOrder => Memo.MemoNumber == "0";


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
            set {

                if (_memoDetails != value)
                {
                    if (value!=null)
                    {
                        value.CollectionChanged += MemoDetails_Changed;
                    }
                    if (_memoDetails!=null)
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

            //OnPropertyChanged(nameof(LineItems));
            //OnPropertyChanged(nameof(Subtotal));
            //OnPropertyChanged(nameof(Tax));
            //OnPropertyChanged(nameof(GrandTotal));
            IsModified = true;
        }


        public string MemoNumber
        { 
            get=> Memo.MemoNumber="1112";

            set
            {
                if (value!=Memo.MemoNumber)
                {
                    Memo.MemoNumber = value;
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
        public DateTime CreatedOn 
        {
            get=>Memo.CreatatedOn;
            set
            {
                if (value != Memo.CreatatedOn
                    )
                {
                    Memo.CreatatedOn = value;
                    OnPropertyChanged();
                }
                }
             }

        public Decimal PatientTotal => Memo.PatientAmmount;

        public Decimal AccountAmmount => Memo.AccountAmmount;

        public string Address 
        {
            get=>Memo.Address;
            set 
            {
                if (Memo.Address!=value)

                {

                    Memo.Address = value;
                    OnPropertyChanged();

                }
            } }

        public string PatientName 
        { get=>Memo.PatientName;
            set
            {
                if (Memo.PatientName!=value)
                {
                    Memo.PatientName = value;
                    OnPropertyChanged();

                }
            } }


        public int AccountId 
        { get=>Memo.AccountId=1;

            set
            {
                if (Memo.AccountId!=value)
                {
                    Memo.AccountId = value;
                } }
             }

        

        public async Task SaveMemoAsync()
        {
            Memo result = null;
            try
            {
                result = await App.Repository.Memo.UpsertAsync(Memo);
            }
          catch(Exception ex)
            {
                throw new MemoSavingException("Unable to Save Memo. There might have been a problem Connecting to Database. Please Try again later", ex);
            }
            if (result!=null)
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
