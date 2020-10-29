using Domin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel;
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
    public sealed partial class AddMemo : Page, INotifyPropertyChanged
    {
        


        public AddMemo()
        {
            this.InitializeComponent();
            
                      
        }

        private MemoViewModel _viewModel;
        public  AtollIslandViewModel  IAVM { get => App.AtollIslandViewModel;  }

        public MemoViewModel ViewModel
        {
            get => _viewModel;

            set {
                if (_viewModel!=value)
                {
                    _viewModel = value;
                    OnPropertyChanged();

                      
                }
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (Patient)e.Parameter;
           

            if (id != null)
            {
                // Order is a new order
                ViewModel = new MemoViewModel(new Memo(id));
            }
            //else
            //{
            //    // Order is an existing order.
            //    var memo = await App.Repository.Memo.GetMemoAsync(id);
            //    ViewModel = new MemoViewModel(memo);
            //}

            base.OnNavigatedTo(e);
        }

        protected  override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            

            base.OnNavigatingFrom(e);
        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void ServiceSuggection_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason==AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ViewModel.UpdateServiceSuggestions(sender.Text);
            }
        }

        private void ServiceSuggection_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        { 
            
            if (args.SelectedItem!=null)
            {
                var selectedService = args.SelectedItem as Service;
                ViewModel.NewMemoDetail.Service = selectedService;
            }
        }

        private async void AppBarSaveButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
                {
                await ViewModel.SaveMemoAsync();
            }
            catch (MemoSavingException ex)
            {
                var dialog = new ContentDialog()
                {
                    Title = "Unable to save",
                    Content = $"There was an error saving your order:\n{ex.Message}",
                    PrimaryButtonText = "OK"
                };

                await dialog.ShowAsync();
            }
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MemoDetails.Add(ViewModel.NewMemoDetail.MemoDetail);
            ClearCandidateService();
        }

        private void ClearCandidateService()
        {
            ServiceSuggection.Text = string.Empty;
            ViewModel.NewMemoDetail = new MemoDetailViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButtonClicked(object sender, RoutedEventArgs e)
        {

            ViewModel.MemoDetails.Remove((sender as FrameworkElement).DataContext as MemoDetail);
        }
    }
}
