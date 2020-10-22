using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel.SettingsViewModelfolder;

namespace UwpApp.ViewModel
{
    public class SettingsViewModel :BindableBase
    {
        public AtollViewModel atollViewModel { get; set; }
        public SettingsViewModel()
        {

            var at = new Atoll();
            at.Id = 1;
            at.AtollName = "H.Dh";
            App.Repository.Atoll.UpsertAsync(at);

        }

        public bool IsLoading { get; private set; }


        public ObservableCollection<AtollViewModel> Atolls { get; } = new ObservableCollection<AtollViewModel>();


        private Atoll _atoll;

        public Atoll Atoll
        {
            get => _atoll;
            set => Set(ref _atoll, value);
        }


        private AtollViewModel _selectedAtoll;

        public AtollViewModel SelectedAtoll
        {
            get => _selectedAtoll;
            set => Set(ref _selectedAtoll, value);
        }


        public async Task GetListOfAtoll()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);
            Atolls.Clear();
            var atolls =await App.Repository.Atoll.GetAsync();
            foreach (var atoll in atolls)
            {
                Atolls.Add(new AtollViewModel(atoll));
            }
        }
    }
}
