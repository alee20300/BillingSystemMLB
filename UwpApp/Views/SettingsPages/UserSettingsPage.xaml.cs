using UwpApp.ViewModel.SettingsViewModelfolder;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SettingsPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserSettingsPage : Page
    {

        public UserSettingViewModel userSettingViewModel { get; set; } = new UserSettingViewModel();
        public UserSettingsPage()
        {
            this.InitializeComponent();
        }
    }
}
