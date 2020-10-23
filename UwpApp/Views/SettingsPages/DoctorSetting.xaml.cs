﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel;
using UwpApp.ViewModel.SettingsViewModelfolder;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SettingsPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorSetting : Page
    {
        SettingsViewModel settingsViewModel { get; set; }
        DoctorViewModel viewModel { get; set; } = new DoctorViewModel();
        public DoctorSetting()
        {
            this.InitializeComponent();
            DataContext = viewModel;
            settingsViewModel = new SettingsViewModel();
        }
    }
}
