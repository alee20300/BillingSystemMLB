using Domin.Data;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Models;

namespace UwpApp.ViewModel.SampleRegisterViewModel
{
    public class BulkSampleMemoViewModel : BindableBase

    {
        private Memo memo;
        private MemoDetail memoDetail;
        private Account account;
        private Service service;
        

        public BulkSampleMemoViewModel(ObservableCollection<SampleRegister> sampleRegisters)
        {
            SampleRegisters = new ObservableCollection<SampleRegister>();
            SampleRegisters = sampleRegisters;
            MakePatients();
        }

        public ObservableCollection<SampleRegister> SampleRegisters { get; set; }

        public  ObservableCollection<PatientModel> MakePatients()
        {
            Patients = new ObservableCollection<PatientModel>();
            foreach (var sample in SampleRegisters)
            {
                 Patients.Add(new PatientModel(sample));
            }
            return  Patients;
        }

        


        public ObservableCollection<PatientModel> Patients { get; set; } 




        #region Public Properties   

        public Memo Memo { get => memo; set => memo = value; }

        public MemoDetail MemoDetail { get => memoDetail; set => memoDetail = value; }

        public Account Account { get => account; set => account = value; }
        public Service Service { get => service; set => service = value; }

        #endregion


       


    }
}
