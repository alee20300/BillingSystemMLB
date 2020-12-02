using BoldReports.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel.ReportsViewModel;
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
    public sealed partial class report : Page
    {

        public Reports Reports { get; set; } = new Reports();
        public report()
        {
            this.InitializeComponent();

            this.Loaded += ReportViewerPage_Loaded;
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
