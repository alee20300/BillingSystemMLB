using BoldReports.Writer;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel.ReportsViewModel;
using UwpApp.Views;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

namespace UwpApp.Helpers
{
     public class PrintToPdfHelper
    {
        public Reports Reports { get; set; }
        public Memo Memo { get; set; }
        public PrintToPdfHelper()
        {
            

        }

        public async void PrintPDF(Memo memo)
        {
            Reports = new Reports(memo);
            //var stream = new InMemoryRandomAccessStream();
            //FileSavePicker fileSavePicker = new FileSavePicker();
            WriterFormat format = WriterFormat.PDF;

            //fileSavePicker.SuggestedFileName = "ExportReport";
            //var savedItem = await fileSavePicker.PickSaveFileAsync();

            //if (savedItem != null)
            //

            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile savedItem =
    await storageFolder.CreateFileAsync("sample.pdf",
        Windows.Storage.CreationCollisionOption.ReplaceExisting);
            //var savedItem = await FileSavePicker.PickSaveFileAsync();
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



            try
            {
                using (IRandomAccessStream stream = await savedItem.OpenAsync(FileAccessMode.ReadWrite))
                {
                    // Write compressed data from memory to file
                    using (Stream outstream = stream.AsStreamForWrite())
                    {
                        byte[] buffer = exportFileStream.ToArray();
                        outstream.Write(buffer, 0, buffer.Length);
                        outstream.Flush();
                    }
                }
                exportFileStream.Dispose();
            }
            catch { }
        }

        ////InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream()
        ////exportFileStream.AsRandomAccessStream
        ////memStream.Position = 0;
        //PdfDocument doc = await PdfDocument.LoadFromStreamAsync(exportFileStream.AsRandomAccessStream());

            
        }

    }

