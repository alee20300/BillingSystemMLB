using Domin.Models;

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







    }


}

