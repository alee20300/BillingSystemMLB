using Domin.Models;
using System.Linq;

namespace UwpApp.ViewModel.ReportsViewModel
{
    public class ReportViewModelM : BindableBase
    {

        public ReportViewModelM(Memo memo)
        {
            Memo = memo;

        }


        public Memo Memo { get; set; }

        private int _memoId;

        public int MemoId
        {
            get => Memo.MemoId;

        }
        private string _name;

        public string PatientName
        {
            get => Memo.PatientName;

        }

        private string _address;

        public string Address
        {
            get => Memo.Address;

        }


        private string _contact;

        public string Contact
        {
            get => Memo.Patient.Contact;

        }
        private int _age;

        public int Age
        {
            get => _age;

        }

        public decimal  PatientAmount
        {
            get => Memo.MemoDetails.Sum(m => m.PaymentDetails.Sum(p => p.Amount));

        }

        public decimal AccountAmount
        {
            get => Memo.MemoDetails.Sum(m => m.PaymentDetails.Sum(p => p.Amount));

        }

        public decimal Total
        {
            get => AccountAmount + PatientAmount;
        }







    }


}

