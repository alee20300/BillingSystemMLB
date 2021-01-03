using Domin.Models;
using UwpApp.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InvoicePage : Page
    {
        
        public InvoiceViewModel InvoiceViewModel { get; set; } = new InvoiceViewModel();
        public InvoicePage()
        {
            this.InitializeComponent();

        }
        public Invoice Invoice { get; set; }
        public AtollIslandViewModel IAVM { get => App.AtollIslandViewModel; }


    }
}
