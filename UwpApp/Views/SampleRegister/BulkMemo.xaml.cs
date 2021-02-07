using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel;
using UwpApp.ViewModel.SampleRegisterViewModel;
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

namespace UwpApp.Views.SampleRegister
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BulkMemo : Page
    {
        public BulkMemo()
        {
            this.InitializeComponent();
            
        }

        public StaticData IAVM { get => App.AtollIslandViewModel; }

        public BulkSampleMemoViewModel bulkMemoViewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ObservableCollection<Domin.Data.SampleRegister> id = (ObservableCollection<Domin.Data.SampleRegister>)e.Parameter;


            if (id != null)
            {
                // Order is a new order
                bulkMemoViewModel = new BulkSampleMemoViewModel(id);

            }
            //else
            //{
            //    // Order is an existing order.
            //    var memo = await App.Repository.Memo.GetMemoAsync(id);
            //    ViewModel = new MemoViewModel(memo);
            //}

            base.OnNavigatedTo(e);
        }


        private void ServiceSuggection_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                bulkMemoViewModel.UpdateServiceSuggestions(sender.Text);
            }
        }

        private void ServiceSuggection_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {


            if (args.SelectedItem != null)
            {

                var selectedService = args.SelectedItem as Service;
                int ser = selectedService.ServiceId;

                bulkMemoViewModel.Services.Add(selectedService);
                bulkMemoViewModel.Service = selectedService;
                bulkMemoViewModel.newmemodetail();

                //if (ViewModel.NewMemoDetail == null)
                //{
                //    ViewModel.NewMemoDetail = new MemoDetailViewModel(ser, ViewModel);
                //}
                //else
                //{
                //    ViewModel.NewMemoDetail = new MemoDetailViewModel(ser, ViewModel);
                //}

                //ViewModel.NewMemoDetail.Service = selectedService;
                //ViewModel.NewMemoDetail.MemoDetail.Service = selectedService;
                //ViewModel.MemoDetails.Add(ViewModel.NewMemoDetail.MemoDetail);
                //ViewModel.updateprice();
                //ClearCandidateService();
            }
        }

    }
}
