using Domin.Data;
using Domin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace UwpApp.ViewModel
{
    public class MemoDetailViewModel : BindableBase
    {
        public MemoDetailViewModel(int ser, MemoViewModel memo)
        {
            MemoDetail = new MemoDetail();
            PaymentDetails = new ObservableCollection<PaymentDetail>(MemoDetail.PaymentDetails);
            var paymenttypes = memo.PaymentTypes;
            foreach (var paymenttype in paymenttypes)
            {
                account(paymenttype.Account, ser);
            }
        }
        public MemoDetail MemoDetail { get; }

        public void account(Account acc, int scc)
        {
            var result = App.Repository.AccountServicePrice.GetAccountServicePrice(acc.AccountId, scc);
            PaymentDetail = new PaymentDetail();
            PaymentDetail.Account = acc;
            PaymentDetail.Amount = result.AccountAmmount;

            //AccountAmmount = result.AccountAmmount;
            //PatientAmount = result.PatientAmmount;
            Rate = result.Rate;
            PaymentDetails.Add(PaymentDetail);
        }

        private ObservableCollection<PaymentDetail> _paymentDetails;


        public ObservableCollection<PaymentDetail> PaymentDetails
        {
            get => _paymentDetails;
            set
            {
                if (_paymentDetails != value)
                {
                    if (value != null)
                    {
                        value.CollectionChanged += PaymentDetails_Changed;
                    }
                    if (_paymentDetails != null)
                    {
                        _paymentDetails.CollectionChanged -= PaymentDetails_Changed;

                    }
                    _paymentDetails = value;
                    OnPropertyChanged();

                }
           

               
            }
        }

        private void PaymentDetails_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PaymentDetails != null)
            {
                MemoDetail.PaymentDetails = PaymentDetails.ToList();
            }

            //OnPropertyChanged(nameof(PatientTotal));
            //OnPropertyChanged(nameof(AccountAmmount));
           
            //OnPropertyChanged(nameof(Tax));
            //OnPropertyChanged(nameof(GrandTotal));
            
        }



        //public ICollection<PaymentDetail> PaymentDetails
        //{ get;
        //    set;



        //    } 
        public PaymentDetail PaymentDetail { get; set; }
        public Service Service
        {
            get => MemoDetail.Service;
            set
            {
                if (MemoDetail.Service != value)
                {
                    MemoDetail.Service = value;
                    OnPropertyChanged();
                }
            }
        }

        //public decimal PatientAmount
        //{
        //    get => MemoDetail.PatientAmmount;
        //    set
        //    {
        //        if (MemoDetail.PatientAmmount != value)
        //        {
        //            MemoDetail.PatientAmmount = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public decimal Rate
        {
            get 
                => MemoDetail.Rate;
            set
            {
                if (MemoDetail.Rate != value)
                {
                    MemoDetail.Rate = value;
                    OnPropertyChanged();
                }
            }
        }

        //public decimal AccountAmmount
        //{
        //    get => MemoDetail.AccountAmmount;
        //    set
        //    {
        //        if (MemoDetail.AccountAmmount != value)
        //        {
        //            MemoDetail.AccountAmmount = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public int Qty
        {
            get => MemoDetail.Qty;
            set
            {
                if (MemoDetail.Qty != value)
                {
                    MemoDetail.Qty = value;
                    OnPropertyChanged();

                }
            }

        }

        public decimal Account 
        { get
            { return PaymentDetails.Sum(PaymentDetails => PaymentDetails.Amount); } 
             }



    }
}
