using Domin.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel
{
    public class InvoiceViewModel : BindableBase
    {
        public InvoiceViewModel()
        {
              InvoiceDetails = new ObservableCollection<InvoiceDetail>();
        }
        public ICommand LoadAccount => new RelayCommand(GetMemos);

        public Account Account { get; set; }

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

        public void SaveMemo()
        {


        }


        public bool Added { get; set; }
        public ObservableCollection<Memo> Memos { get; set; } = new ObservableCollection<Memo>();
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
    }
}
