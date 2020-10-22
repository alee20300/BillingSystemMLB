using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel;
using UwpApp.ViewModel.SettingsViewModelfolder;
using UwpApp.Views.SettingsPages;
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

namespace UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public AtollViewModel ViewModel { get; set; } = new AtollViewModel();
        public SettingsViewModel SettingsViewModel { get; set; } = new SettingsViewModel();
        public SettingsPage()
        {
            this.InitializeComponent();
            DataContext = ViewModel;
            
        }

        private void AccoutSettingframe_Loaded(object sender, RoutedEventArgs e)
        {
            AccoutSettingframe.Navigate(typeof(AccountsSetting));

        }

        private void ServiceSettingFrame_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceSettingFrame.Navigate(typeof(ServiceSetting));
        }

        private void DoctorSettingFrame_Loaded(object sender, RoutedEventArgs e)
        {
            DoctorSettingFrame.Navigate(typeof(DoctorSetting));
        }
    }
}
