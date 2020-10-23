﻿using Domin.Models;
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

           Task.Run( GetListOfDoctor);
            Task.Run(GetListOfAtoll);

        }

        public bool IsLoading { get; private set; }


        public ObservableCollection<AtollViewModel> Atolls { get; } = new ObservableCollection<AtollViewModel>();
        public ObservableCollection<DoctorViewModel> Doctors { get; } = new ObservableCollection<DoctorViewModel>();


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

        private DoctorViewModel  _selectedDoctor;

        public DoctorViewModel SelectedDoctor
        {
            get => _selectedDoctor;
            set => Set(ref _selectedDoctor, value);
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

        public async Task GetListOfDoctor()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);
            Doctors.Clear();
            var doctors = await App.Repository.Doctor.GetAsync();
            foreach (var doctor in doctors )
            {
                Doctors.Add(new DoctorViewModel(doctor));
            }
        }
    }
}
