using Domin.Data;
using System;
using System.Collections;
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
        private ObservableCollection<SampleRegister> samplestoMakeMemo;

        public SampleRegisterViewModel()
        {
            Task.Run(GetSampleRegister);

            samplestoMakeMemo = new ObservableCollection<SampleRegister>();


        }
        public ObservableCollection<SampleRegister> Samples { get; set; } = new ObservableCollection<SampleRegister>();

        public SampleRegister SampleRegister = new SampleRegister();
        private string recivedby;

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
                if (SampleRegister.SampleNumber != value)
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
                if (SampleRegister.CollectedDate != value
                    )
                {
                    CollectedDate = value;
                    OnPropertyChanged();

                }
            }
        }


        public DateTime RecivedTime
        {
            get => SampleRegister.RecivedDate;
            set
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
            get => recivedby;
            set
            {

                if (recivedby!=value)
                {
                    recivedby = value;
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

        public IList SelectedItems { get; set; }


        public void ChangeStatus(status status)
        {
            Status = status;
        }

        public async Task GetSampleRegister()
        {
            var results = await App.Repository.SampleRegisterRepository.GetAsync();
            Samples.Clear();
            foreach (var result in results)
            {
                Samples.Add(result);
            }

        }

        public ICommand AddSamplerelay => new RelayCommand(AddSample);


        public async Task SaveSample(SampleRegister sampleRegister)
        {
            if (sampleRegister != null)
            {

                try
                {
                    var result = await App.Repository.SampleRegisterRepository.UpsertAsync(sampleRegister);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }
        }
        public async void AddSample()
        {
            SaveSample(SampleRegister);
        }

        public ObservableCollection<SampleRegister> SamplestoMakeMemo { get => samplestoMakeMemo; set => samplestoMakeMemo = value; }

    }
}
