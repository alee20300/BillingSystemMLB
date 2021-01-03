using UwpApp.ViewModel;
using UwpApp.ViewModel.SettingsViewModelfolder;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SettingsPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountsSetting : Page
    {
        AtollIslandViewModel avmodel = new AtollIslandViewModel();
        AccountViewModel viewModel { get; set; } = new AccountViewModel();
        public AccountsSetting()
        {
            this.InitializeComponent();
            DataContext = viewModel;
        }
    }
}
