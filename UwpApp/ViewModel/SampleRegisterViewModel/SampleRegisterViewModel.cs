using Domin.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.SampleRegisterViewModel
{
    public class SampleRegisterViewModel : BindableBase

    {
        private status status;
        private ObservableCollection<SampleRegister> samplestoMakeMemo;

        public SampleRegisterViewModel()
        {

        }
        public ObservableCollection<SampleRegister> Samples { get; set; } = new ObservableCollection<SampleRegister>();

        public SampleRegister SampleRegister { get; set; }

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
                    SampleNumber = value;
                    OnPropertyChanged();

                }
            }

        }
        public DateTime CollectedDate
        {

            get => SampleRegister.CollectedDate;

            set
            {
                if (value != SampleRegister.CollectedDate
                    )
                {
                    CollectedDate = value;
                    OnPropertyChanged();

                }
            }
        }


        public DateTime RecivedTime
        {
            get => SampleRegister.RecivedDate; set
            {
                if (value != SampleRegister.RecivedDate)
                {
                    RecivedTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Recivedby
        {
            get => SampleRegister.RecivedBy; set
            {
                if (value != SampleRegister.RecivedBy)
                {
                    Recivedby = value;
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


        public void ChangeStatus(status status)
        {
            Status = status;
        }

        public void AddSample(SampleRegister sampleRegister)
        {
            if (sampleRegister != null)
            {

                try
                {
                    App.Repository.SampleRegisterRepository.UpsertAsync(sampleRegister);

                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        public ObservableCollection<SampleRegister> SamplestoMakeMemo { get => samplestoMakeMemo; set => samplestoMakeMemo = value; }

    }
}
