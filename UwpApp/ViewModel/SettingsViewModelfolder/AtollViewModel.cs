using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.I2c;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
   public class AtollViewModel :BindableBase
    {
        public AtollViewModel(Atoll atoll =null)
        {
            Atoll = atoll ?? new Atoll();


        }


        private bool _IsLoading = false;

        public bool Isloading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }



        private Atoll _atoll;

        public Atoll Atoll
        {
            get => _atoll;
            set {
                if (value!=_atoll)
                {
                    _atoll = value;
                    OnPropertyChanged(string.Empty);

                }
            }

        }

        public int Id
        {
            get => Atoll.Id;
            set
            {
                if (value != Atoll.Id)

                {
                    Atoll.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AtollName 
        {
            get => Atoll.AtollName;
            set
            {
                if (value != Atoll.AtollName)

                {
                    Atoll.AtollName = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
