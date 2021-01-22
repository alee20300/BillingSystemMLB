using Domin.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UwpApp.Models;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel
{
    public class InvoiceViewModel : BindableBase
    {
        public InvoiceViewModel()
        {
            Invoice = new Invoice();
              InvoiceDetails = new ObservableCollection<InvoiceDetail>();
        }
        public ICommand LoadAccount => new RelayCommand(GetMemos);
        public ICommand SaveInvoice => new RelayCommand(SaveMemo);

        public Account Account
        {
            get=>Invoice.Account ;
            set
            {
                if (Invoice. Account!=value)
                {
                    Invoice. Account = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<InvoiceDetail> _invoiceDetails;
        public Invoice Invoice { get; set; }

        public DateTimeOffset DateTimeOffsetfrom { get; set; }
        public DateTimeOffset DateTimeOffsetto { get; set; }

        public async void GetMemos()
        {
            var memos = await App.Repository.Memo.GetMemoForInvoice(DateTimeOffsetfrom, DateTimeOffsetto, Account.AccountId);
            Memos.Clear();
            foreach (var memo in memos)
            {
                Memos.Add(memo);
               
            }

        }

        public async void SaveMemo()
        {
            Invoice result = null;
            try
            {

                result = await App.Repository.Invoices.UpsertAsync(Invoice);
            }
            catch (Exception ex)
            {
                throw new MemoSavingException("Unable to Save Memo. There might have been a problem Connecting to Database. Please Try again later", ex);
            }

        }


        public bool Added { get; set; }
        public ObservableCollection<object> Memos { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<InvoiceDetail> InvoiceDetails
        {
            get => _invoiceDetails;
            set
            {
                if (_invoiceDetails != value)
                {
                    _invoiceDetails = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal InvoviceAmmount
        {
            get => Invoice.InvoiceAmmount;
            set
            {
                if (Invoice.InvoiceAmmount != value)
                {
                    Invoice.InvoiceAmmount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MyProperty { get; set; }
        public DateTime InvoiceDate 
        { 
            get => _invoiceDate = DateTime.Now;
           
        } 





        private DateTime _invoiceDate;

       



    }
}
