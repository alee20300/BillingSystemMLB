using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel
{
   public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            
        }
        public ICommand LoadAccount => new RelayCommand(GetMemos);

        public Account Account { get; set; }

       

        public DateTimeOffset DateTimeOffsetfrom  { get; set; }
        public DateTimeOffset  DateTimeOffsetto  { get; set; }

        public async void   GetMemos()
        {
            var memos = await App.Repository.Memo.GetMemoForInvoice(DateTimeOffsetfrom,DateTimeOffsetto , Account.AccountId);
            Memos.Clear();
            foreach (var memo in memos)
            {
                Memos.Add(memo);
            }

        }

        
        public bool Added { get; set; }
        public ObservableCollection<Memo> Memos { get; set; } = new ObservableCollection<Memo>();
    }
}
