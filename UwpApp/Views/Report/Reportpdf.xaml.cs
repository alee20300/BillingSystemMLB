using BoldReports.Writer;
using Domin.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using UwpApp.ViewModel.ReportsViewModel;
using Windows.Data.Pdf;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.Report
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Reportpdf : Page
    {

        public Reports Reports { get; set; }
        public Reportpdf(Memo memo)
        {
            this.InitializeComponent();
            Memo = memo;
        }

        public Memo Memo { get; set; }
        async void Load(PdfDocument pdfDoc)
        {
            PdfPages.Clear();

            for (uint i = 0; i < pdfDoc.PageCount; i++)
            {
                BitmapImage image = new BitmapImage();

                var page = pdfDoc.GetPage(i);

                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await page.RenderToStreamAsync(stream);
                    await image.SetSourceAsync(stream);
                }

                PdfPages.Add(image);
            }
        }


        public ObservableCollection<BitmapImage> PdfPages
        {
            get;
            set;
        } = new ObservableCollection<BitmapImage>();
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            Reports = new Reports(Memo);
            //var stream = new InMemoryRandomAccessStream();
            //FileSavePicker fileSavePicker = new FileSavePicker();
            WriterFormat format = WriterFormat.PDF;

            //fileSavePicker.SuggestedFileName = "ExportReport";
            //var savedItem = await fileSavePicker.PickSaveFileAsync();

            //if (savedItem != null)
            //

            MemoryStream exportFileStream = new MemoryStream();

            Assembly assembly = typeof(HomePage).GetTypeInfo().Assembly;
            // Ensure the report loaction and application name.
            Stream reportStream = assembly.GetManifestResourceStream("UwpApp.Report.Inv.rdlc");

            BoldReports.UI.Xaml.ReportDataSourceCollection datas = new BoldReports.UI.Xaml.ReportDataSourceCollection();
            datas.Add(new BoldReports.UI.Xaml.ReportDataSource { Name = "PatientInfo", Value = Reports.LoadReport() });
            datas.Add(new BoldReports.UI.Xaml.ReportDataSource { Name = "MemoDetails", Value = Reports.loadmemodetail() });




            ReportWriter writer = new ReportWriter(reportStream, datas);
            writer.ExportMode = ExportMode.Local;
            await writer.SaveASync(exportFileStream, format);




            //InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream()
            //exportFileStream.AsRandomAccessStream
            //memStream.Position = 0;
            PdfDocument doc = await PdfDocument.LoadFromStreamAsync(exportFileStream.AsRandomAccessStream());

            Load(doc);
        }
    }
}



