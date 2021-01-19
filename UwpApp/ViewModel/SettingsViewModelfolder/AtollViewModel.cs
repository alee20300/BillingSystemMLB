using Domin.Models;
using System.Windows.Input;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class AtollViewModel : BindableBase
    {
        public AtollViewModel(Atoll atoll = null)
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
            set
            {
                if (value != _atoll)
                {
                    _atoll = value;
                    OnPropertyChanged(string.Empty);

                }
            }

        }

        public int Id
        {
            get => Atoll.AtollId;
            set
            {
                if (value != Atoll.AtollId)

                {
                    Atoll.AtollId = value;
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


        public ICommand Add => new RelayCommand<Atoll>(AddAsync);

        public void AddAsync(Atoll atoll)
        {
            var result = App.Repository.Atoll.UpsertAsync(atoll);



        }
    }
}
