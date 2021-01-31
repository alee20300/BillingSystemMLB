using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.SampleRegisterViewModel
{
    public class SampleRegisterViewModel : BindableBase

    {
        private status status;
        private SampleRegister sampleRegister;
        public Memo Memo { get; set; }
       

        public SampleRegisterViewModel()
        {
            Task.Run(LoadSample);
            SampleRegister = new SampleRegister();
        }

        public ObservableCollection<SampleRegister> Samples { get; set; } = new ObservableCollection<SampleRegister>();
        #region Public Properties
        public SampleRegister SampleRegister

        {
            get => sampleRegister;

            set
            {
                if (value != sampleRegister)
                {
                    sampleRegister = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SampleRegisterId
        {


            get => SampleRegister.ReisterId;
            set
            {
                if (value != SampleRegister.ReisterId)

                {
                    SampleRegisterId = value;
                    OnPropertyChanged();

                }
            }
        }
        public string SampleNumber
        {
            get => SampleRegister.SampleNumber;

            set
            {
                if (value != SampleRegister.SampleNumber)
                {
                    SampleRegister.SampleNumber = value;
                    OnPropertyChanged();

                }
            }

        }
        public DateTime CollectedDate
        {

            get => SampleRegister.CollectedDate;

            set
            {
                if (value != CollectedDate)
                {
                    SampleRegister.CollectedDate = value;
                    OnPropertyChanged();

                }
            }
        }
        public DateTime RecivedDate
        {
            get => SampleRegister.RecivedDate;
            set
            {
                if (value != RecivedDate)
                {
                    SampleRegister.RecivedDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Recivedby
        {
            get => SampleRegister.RecivedBy;
            set
            {
                if (value != SampleRegister.RecivedBy)
                {
                    SampleRegister.RecivedBy = value;
                    OnPropertyChanged();
                }
            }
        }
        public status Status
        {
            get => SampleRegister.Status;
            set
            {
                if (SampleRegister.Status != value)
                {
                    Status = value;
                    OnPropertyChanged();
                }
            }

        }
        #endregion


        #region Commands

        public ICommand SaveSample => new RelayCommand(AddSample);

        public ICommand MakeMemo => new RelayCommand(Addpatientstodb);

        public ICommand add => new RelayCommand(addsamplesto);
        #endregion
        public void ChangeStatus(status status)
        {
            Status = status;
        }


       

        public async void AddSample()
        {
            if (SampleRegister != null)

            {



                try
                {
                    var result = await App.Repository.SampleRegisterRepository.UpsertAsync(SampleRegister);

                }
                catch (Exception ex)
                {
                    throw new MemoSavingException("Unable to Save Memo. There might have been a problem Connecting to Database. Please Try again later", ex);
                }


                UpdateBindings();


            }
        }

        public void UpdateBindings()
        {
            Samples.Add(SampleRegister);
            SampleRegister = new SampleRegister();
            OnPropertyChanged(nameof(SampleNumber));
            OnPropertyChanged(nameof(CollectedDate));
            OnPropertyChanged(nameof(RecivedDate));
            OnPropertyChanged(nameof(Recivedby));
            OnPropertyChanged(nameof(status));

        }

        List<Patient> patients = new List<Patient>();


        public async Task LoadSample()
        {
            var samples = await App.Repository.SampleRegisterRepository.GetAsync();
            Samples.Clear();
            foreach (var sample in samples)
            {
                Samples.Add(sample);
                MakePatientFromSample(sample);

            }
        }


        

        public async void Addpatientstodb()
        {

            try
            {
                await App.Repository.Patient.bulkinsertpatient(patients);




            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void MakePatientFromSample(SampleRegister sampleRegister)
        {
            Patient patient = new Patient();
            patient.PatientName = sampleRegister.SampleNumber;
            patient.IdCardNumber = sampleRegister.SampleNumber;
            patient.PermAddress = "C/O National Drug Agency";
            patient.Sex = "U";
            patient.AtollId = 1;
            patient.IslandId = 1;
            patient.CountryId = 1;

            patients.Add(patient);
            //MakeMemoFromSample(patient);

        }

        public ObservableCollection<SampleRegister> SamplesToMakeMemo = new ObservableCollection<SampleRegister>();
        private Account account;

        public SampleRegister SelectedSampleReg
        {
            get;
            set;
        }

       

        public Account Account { get; set; }


        public void addsamplesto()
        {
            SamplesToMakeMemo.Add(SelectedSampleReg);
        }
        public async void MakeMemoFromSample(Patient patient)
        {
            List<PaymentDetail> paymentDetails = new List<PaymentDetail>();
            PaymentDetail paymentDetail = new PaymentDetail();
            paymentDetail.Account = await App.Repository.Account.GetAccountbyIdInt("CASH");
            paymentDetail.Amount = 100;
            paymentDetails.Add(paymentDetail);


            List<MemoDetail> memoDetails = new List<MemoDetail>();
            MemoDetail memoDetail = new MemoDetail();

            memoDetail.Qty = 1;
            memoDetail.Service = await App.Repository.Service.GetbyIdAsync(1);
            memoDetail.ServiceId = 1;
            memoDetail.PaymentDetails = paymentDetails;
            memoDetails.Add(memoDetail);






            Memo memo = new Memo();
            memo.Address = patient.PermAddress;
            memo.Patient = patient;
            memo.Doctor = App.Repository.Doctor.GetDocById(1);
            memo.DoctorId = 1;
            memo.PatientName = patient.PatientName;
            memo.MemoDetails = memoDetails;

            try
            {
                await App.Repository.Memo.UpsertAsync(memo);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}

