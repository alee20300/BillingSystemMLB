using BoldReports.UI.Xaml;
using Domin.Models;
using System.IO;
using System.Reflection;
using UwpApp.ViewModel.ReportsViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class report : Page
    {
        public Reports Reports { get; set; }

        public report()
        {
            this.InitializeComponent();

            this.Loaded += ReportViewerPage_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (Memo)e.Parameter;


            if (id != null)
            {
                // Order is a new order
                Reports = new Reports(id);
            }
            //else
            //{
            //    // Order is an existing order.
            //    var memo = await App.Repository.Memo.GetMemoAsync(id);
            //    ViewModel = new MemoViewModel(memo);
            //}

            base.OnNavigatedTo(e);
        }


        private void ReportViewerPage_Loaded(object sender, RoutedEventArgs e)
        {
            Assembly assembly = typeof(HomePage).GetTypeInfo().Assembly;
            Stream reportStream = assembly.GetManifestResourceStream("UwpApp.Report.Inv.rdlc");
            this.ReportViewer.ProcessingMode = BoldReports.UI.Xaml.ProcessingMode.Local;
            this.ReportViewer.LoadReport(reportStream);
            this.ReportViewer.DataSources.Add(new ReportDataSource { Name = "PatientInfo", Value = Reports.LoadReport() });
            this.ReportViewer.DataSources.Add(new ReportDataSource { Name = "MemoDetails", Value = Reports.loadmemodetail() });

            this.ReportViewer.RefreshReport();
        }
    }
}
