using BoldReports.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel.ReportsViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
        public Reportpdf()
        {
            this.InitializeComponent();
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
           
            Reports = new Reports(4);
            //var stream = new InMemoryRandomAccessStream();
            //FileSavePicker fileSavePicker = new FileSavePicker();
            WriterFormat format = WriterFormat.PDF;

            //fileSavePicker.SuggestedFileName = "ExportReport";
            //var savedItem = await fileSavePicker.PickSaveFileAsync();

            //if (savedItem != null)
            //

                MemoryStream exportFileStream = new MemoryStream();
                Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
                // Ensure the report loaction and application name.
                Stream reportStream = assembly.GetManifestResourceStream("UwpApp.Report.Inv.rdlc");

                BoldReports.UI.Xaml.ReportDataSourceCollection datas = new BoldReports.UI.Xaml.ReportDataSourceCollection();
                datas.Add(new BoldReports.UI.Xaml.ReportDataSource { Name = "PatientInfo", Value = Reports.LoadReport() });
                datas.Add(new BoldReports.UI.Xaml.ReportDataSource { Name = "MemoDetails", Value = Reports.loadmemodetail() });

                ReportWriter writer = new ReportWriter(reportStream, datas);
                writer.ExportMode = ExportMode.Local;

            

            await writer.SaveASync(exportFileStream, format);


            //    try
            //{
            //    using (IRandomAccessStream stream = await sampleFile.OpenAsync(FileAccessMode.ReadWrite))
            //    {
            //        // Write compressed data from memory to le
            //        using (Stream outstream = stream.AsStreamForWrite())
            //        {
            //            byte[] buffer = exportFileStream.ToArray();
            //            outstream.Write(buffer, 0, buffer.Length);
            //            outstream.Flush();
            //        }
            //    }
            //    exportFileStream.Dispose();
            //}
            //catch { }
        


        BitmapImage src = new BitmapImage();
            Output.Source = src;
            await src.SetSourceAsync(exportFileStream.AsRandomAccessStream());
            }
    }}

    

