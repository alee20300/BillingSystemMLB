using Domin.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UwpApp.ViewModel;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMemo : Page, INotifyPropertyChanged
    {

        private AppWindow AppWindow { get; set; }
        private Frame appWindowFrame = new Frame();


        public AddMemo()
        {
            this.InitializeComponent();


        }

        private MemoViewModel _viewModel;
        public StaticData IAVM { get => App.AtollIslandViewModel; }



        public MemoViewModel ViewModel
        {
            get => _viewModel;

            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    OnPropertyChanged();


                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
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

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {


            base.OnNavigatingFrom(e);
        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void ServiceSuggection_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ViewModel.UpdateServiceSuggestions(sender.Text);
            }
        }

        private void ServiceSuggection_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

            if (args.SelectedItem != null)
            {

                var selectedService = args.SelectedItem as Service;
                int ser = selectedService.ServiceId;

                if (ViewModel.NewMemoDetail == null)
                {
                    ViewModel.NewMemoDetail = new MemoDetailViewModel(ser, 1);
                }
                else
                {
                    ViewModel.NewMemoDetail = new MemoDetailViewModel(ser, 1);
                }

                ViewModel.NewMemoDetail.Service = selectedService;
                ViewModel.NewMemoDetail.MemoDetail.Service = selectedService;
                ViewModel.MemoDetails.Add(ViewModel.NewMemoDetail.MemoDetail);
                ClearCandidateService();
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

            if (AppWindow == null)
            {
                // Create a new window
                AppWindow = await AppWindow.TryCreateAsync();
                // Make sure we release the reference to this window, and release XAML resources, when it's closed
                AppWindow.Closed += delegate { AppWindow = null; appWindowFrame.Content = null; };
                // Navigate the frame to the page we want to show in the new window
                appWindowFrame.Navigate(typeof(report), ViewModel.Memo);
                // Attach the XAML content to our window
                ElementCompositionPreview.SetAppWindowContent(AppWindow, appWindowFrame);
            }

            // Now show the window
            await AppWindow.TryShowAsync();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MemoDetails.Add(ViewModel.NewMemoDetail.MemoDetail);
            ClearCandidateService();
        }

        private void ClearCandidateService()
        {
            ServiceSuggection.Text = string.Empty;
            //ViewModel.NewMemoDetail = new MemoDetailViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButtonClicked(object sender, RoutedEventArgs e)
        {

            ViewModel.MemoDetails.Remove((sender as FrameworkElement).DataContext as MemoDetail);
        }

        private void AccountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {

            var acc = (Account)e.OriginalSource;
            
            
            ViewModel.AddPaymentType(acc);
        }
    }
}
