using UwpApp.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SettingsPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServiceSetting : Page
    {
        public SettingsViewModel viewModel { get; set; }
        public ServiceSetting()
        {
            viewModel = new SettingsViewModel();
            this.InitializeComponent();

        }
    }
}
