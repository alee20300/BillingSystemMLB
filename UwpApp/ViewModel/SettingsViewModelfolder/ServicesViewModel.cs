using Domin.Models;
using System.Windows.Input;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class ServicesViewModel : BindableBase
    {
        public ServicesViewModel(Service service = null)
        {
            Service = service ?? new Service();

        }



        private bool _IsLoading = false;

        public bool Isloading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }

        private Service _service;

        public Service Service
        {
            get => _service;
            set
            {
                if (value != _service)
                {
                    _service = value;
                    OnPropertyChanged(string.Empty);
                }

            }
        }

        public int Id
        {
            get => Service.ServiceId;
            set
            {
                if (value != Service.ServiceId)
                {
                    Service.ServiceId = value;
                    OnPropertyChanged();
                }
            }
        }


        public string ServiceCode
        {
            get => Service.ServiceCode;
            set
            {
                if (value != Service.ServiceCode)
                {
                    Service.ServiceCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ServiceName
        {
            get => Service.ServiceName;
            set
            {
                if (value != Service.ServiceName)
                {
                    Service.ServiceName = value;
                    OnPropertyChanged();
                }
            }
        }

        public Catogory Catogory
        {
            get => Service.Catogory;
            set
            {
                if (value != Service.Catogory)
                {
                    Service.Catogory = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ICode
        {
            get => Service.ICode;
            set
            {
                if (value != Service.ICode)
                {
                    Service.ICode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LisCode
        {
            get => Service.LisCode;
            set
            {
                if (value != Service.LisCode)
                {
                    Service.LisCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Rate
        {
            get => Service.Rate;
            set
            {
                if (value != Service.Rate)
                {
                    Service.Rate = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => Service.IsActive;
            set
            {
                if (value != Service.IsActive)
                {
                    Service.IsActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Add => new RelayCommand<Service>(AddAsync);

        public void AddAsync(Service service)
        {
            var result = App.Repository.Service.UpsertAsync(service);



        }
    }
}
