using UwpApp.ViewModel;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UwpApp.UserControls
{
    public sealed partial class PatientCard : UserControl
    {
        public ShellViewModel ViewModel { get; set; }
        public PatientCard()
        {
            this.InitializeComponent();
            DataContext = App.ShellViewModel;
        }
    }
}
