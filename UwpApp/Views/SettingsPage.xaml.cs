using UwpApp.ViewModel;
using UwpApp.ViewModel.SettingsViewModelfolder;
using UwpApp.Views.SettingsPages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
