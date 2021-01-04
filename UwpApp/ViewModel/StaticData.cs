using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UwpApp.ViewModel.SettingsViewModelfolder;

namespace UwpApp.ViewModel
{
    public class StaticData
    {
        public StaticData()
        {
            Atolls = new List<Atoll>();
            Country = new List<Country>();
            MasterIslandList = new List<Island>();
            Task.Run(GetAtoll);
            Task.Run(getIslandList);
            Task.Run(getCountryList);
            Task.Run(GetAccounts);
            Task.Run(GetCollectionSite);
            Task.Run(getDoctors);

        }

        public ObservableCollection<DoctorViewModel> Doctors { get; set; } = new ObservableCollection<DoctorViewModel>();

        private async void getDoctors()
        {

            var results = await App.Repository.Doctor.GetAsync();
            Doctors.Clear();
            foreach (var result in results)
            {
                Doctors.Add(new DoctorViewModel(result));

            }



        }

        public ObservableCollection<CollectionSiteViewModel> CollectionSites { get; set; } = new ObservableCollection<CollectionSiteViewModel>();

        private async Task GetCollectionSite()
        {
            var sites = await App.Repository.CollectionSite.GetAsync();
            CollectionSites.Clear();
            foreach (var site in sites)
            {
                CollectionSites.Add(new CollectionSiteViewModel(site));
            }

        }

        private async Task GetAtoll()
        {
            var atolls = await App.Repository.Atoll.GetAsync();
            Atolls.Clear();
            foreach (var atoll in atolls)
            {
                Atolls.Add(atoll);

            }

        }


        private async Task GetAccounts()
        {
            var accounts = await App.Repository.Account.GetAsync();
            Accounts.Clear();
            foreach (var account in accounts)
            {
                Accounts.Add(new AccountViewModel(account));

            }

        }

        private async Task getIslandList()
        {
            var islands = await App.Repository.Island.GetAsync();
            MasterIslandList.Clear();
            foreach (var island in islands)
            {
                MasterIslandList.Add(island);
            }

        }

        private async Task getCountryList()
        {
            var countries = await App.Repository.Country.GetAsync();
            Country.Clear();
            foreach (var country in countries)
            {
                Country.Add(country);
            }

        }


        public List<Country> Country { get; set; }

        public List<Atoll> Atolls { get; set; }
        public ObservableCollection<AccountViewModel> Accounts { get; set; } = new ObservableCollection<AccountViewModel>();

        public List<Island> MasterIslandList { get; } = new List<Island>();

        public ObservableCollection<Island> Islands { get; } = new ObservableCollection<Island>();

        public void UpdateIslands(string atollid)
        {
            Islands.Clear();
            if (!string.IsNullOrEmpty(atollid))
            {
                string[] parameters = atollid.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                var resultlist = MasterIslandList
                    .Where(island => parameters
                    .Any(parameter =>
                    island.Atoll.AtollId.ToString().StartsWith(parameter)))
                    ;
                foreach (var island in resultlist)
                {
                    Islands.Add(island);
                }


            }
        }

    }
}
