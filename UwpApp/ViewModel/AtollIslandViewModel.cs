﻿using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel
{
    public class AtollIslandViewModel
    {
        public AtollIslandViewModel()
        {
            Atolls = new List<Atoll>();

            MasterIslandList = new List<Island>();
            Task.Run(GetAtoll);
            Task.Run(getIslandList);

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

        private async Task getIslandList()
        {
            var islands = await App.Repository.Island.GetAsync();
            MasterIslandList.Clear();
            foreach (var island in islands)
            {
                MasterIslandList.Add(island);
            }

        }

        public List<Atoll> Atolls { get; set; }

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
                    island.Atoll.Id.ToString().StartsWith(parameter)))
                    ;
                foreach (var island in resultlist)
                {
                    Islands.Add(island);
                }


            }
        }

    }
}
