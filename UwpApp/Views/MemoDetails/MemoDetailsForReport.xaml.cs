using Domin.Models;
using UwpApp.ViewModel.ReportsViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.MemoDetails
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MemoDetailsForReport : Page
    {

        public Reports report { get; set; }
        public MemoDetailsForReport()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Memo memo = (Memo)e.Parameter;

            if (memo != null)
            {
                report = new Reports(memo);
            }


        }
    }
}
