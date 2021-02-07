using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Helpers;
using UwpApp.Models;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.SampleRegisterViewModel
{
    public class BulkSampleMemoViewModel : BindableBase

    {
        private Memo memo;
        private MemoDetail memoDetail;
        private string accountid;
        private Service service;
        private Account account;
        public PrintToPdfHelper PrintToPdf { get; set; }

        public BulkSampleMemoViewModel(ObservableCollection<SampleRegister> sampleRegisters)
        {
            SampleRegisters = new ObservableCollection<SampleRegister>();
            SampleRegisters = sampleRegisters;
            MakePatients();
        }

        public ObservableCollection<SampleRegister> SampleRegisters { get; set; }

        public ObservableCollection<PatientModel> MakePatients()
        {
            Patients = new ObservableCollection<PatientModel>();
            foreach (var sample in SampleRegisters)
            {
                Patients.Add(new PatientModel(sample));
            }
            return Patients;
        }




        public ObservableCollection<PatientModel> Patients { get; set; }
        public ObservableCollection<Service> Services { get; set; } = new ObservableCollection<Service>();

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



        #region Public Properties   

        public Memo Memo { get => memo; set => memo = value; }

        public MemoDetail MemoDetail { get => memoDetail; set => memoDetail = value; }


        public Account Account { get => account; set => account = value; }
        public string Accountid

        {
            get => accountid = "Cash";

            set
            {

                if (value != accountid)
                {
                    Accountid = value;
                    Account = App.Repository.Account.GetAccountbyIdInt(accountid).Result;

                    OnPropertyChanged();

                }
            }
        }
        public Service Service { get => service; set => service = value; }
        public Doctor Doctor
        {
            get => App.Repository.Doctor.GetDocById(1);
        }
        #endregion


        public ICommand Save => new RelayCommand(makebulkmemos);

        public void save()

        {


        }


        public void newmemodetail()
        {
            memoDetail = new MemoDetail();
            memoDetail.Qty = 1;
            memoDetail.Service = service;
            memoDetail.Rate = service.Rate;
            memoDetail.PaymentDetails = new List<PaymentDetail>();
            memoDetail.PaymentDetails.Add(new PaymentDetail { Account = account,  Amount = service.Rate });
            memoDetails.Add(memoDetail);

        }

        public List<MemoDetail> memoDetails { get; set; } = new List<MemoDetail>();




        public ObservableCollection<Memo> Memos { get; set; } = new ObservableCollection<Memo>();

        public void makebulkmemos()
        {
            try
            {
                foreach (var P in Patients)
                {
                    Makememo(P);
                }

                Task.Run(MemosAsync);


            }
            catch (Exception)
            {

                throw;
            }

           

            
           
        }


       public async Task<IEnumerable<Memo>> MemosAsync()
        {

            try
            {

                PrepMemo = await App.Repository.Memo.UpsrBulk(Memos);


            }
            catch (Exception Ex)
            {

                throw;
            }

            return PrepMemo;

        }

        public IEnumerable<Memo> PrepMemo { get; set; } 
        public ICommand PrintMemo => new RelayCommand(printMemo);

        public void printMemo()
        {

            PrintToPdf = new PrintToPdfHelper();
            foreach (var p in PrepMemo)
            {
                PrintToPdf.PrintPDF(p);

            }
        }

        public void Makememo(PatientModel patientModel)
        {
            memo = new Memo();
            memo.Doctor = Doctor;
            memo.Rate = memoDetails.Sum(memoDetails => memoDetails.Rate);
            memo.MemoDate = DateTime.Now;
            memo.MemoDetails = memoDetails;
            memo.PatientId = patientModel.PatientId;
            memo.Address = patientModel.PermAddress;
            memo.PatientName = patientModel.PatientName;





            Memos.Add(memo);


        }




    }
}
