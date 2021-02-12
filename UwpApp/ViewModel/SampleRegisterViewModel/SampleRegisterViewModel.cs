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
            SampleRegister = new SampleRegister();
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
            get => SampleRegister.RecivedBy; 
            set
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

        public void AddSample()
        {
            if (SampleRegister != null)
            {

                try
                {
                    App.Repository.SampleRegisterRepository.UpsertAsync(SampleRegister);

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
