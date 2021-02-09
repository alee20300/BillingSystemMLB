using Domin.Models;
using System;
using System.Threading.Tasks;
using UwpApp.UserControls;
using UwpApp.ViewModel;
using UwpApp.Views.MemoDetails;
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
    public sealed partial class HomePage : Page
    {

        private AppWindow AppWindow { get; set; }
        private Frame appWindowFrame = new Frame();


        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += ReportViewerPage_Loaded;

        }
        //public Reports Reports { get; set; } = new Reports();

        private async void ShowNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new window.
            // Only ever create one window. If the AppWindow already exists call TryShow on it to bring it to foreground.
            if (AppWindow == null)
            {
                // Create a new window
                AppWindow = await AppWindow.TryCreateAsync();
                // Make sure we release the reference to this window, and release XAML resources, when it's closed
                AppWindow.Closed += delegate { AppWindow = null; appWindowFrame.Content = null; };
                // Navigate the frame to the page we want to show in the new window
                appWindowFrame.Navigate(typeof(report));
                // Attach the XAML content to our window
                ElementCompositionPreview.SetAppWindowContent(AppWindow, appWindowFrame);
            }

            // Now show the window
            await AppWindow.TryShowAsync();
            // ...
        }
        public ShellViewModel ViewModel
        {
            get
            {
                return App.ShellViewModel;
            }
        }

        private void ReportViewerPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


        }
        private async void AutoSuggestBox_TextChangedAsync(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput && sender.Text.Length > 3)
            {

                await ViewModel.updatepstientSuggestion(sender.Text);

                if (ViewModel.PatientSuggestion?.Count == 0)
                {
                    addpatientframe.Navigate(typeof(AddPatient), null);
                    return;
                }
                else
                {
                    sender.ItemsSource = ViewModel.PatientSuggestion;
                }

            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            ViewModel.SelectedPatient = new PatientViewModel(args.SelectedItem as Patient);


        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.

            }
        }

        private void AddmemoPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) =>

            Frame.Navigate(typeof(AddMemo), ViewModel.SelectedPatient.Patient);

        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(ViewModel.SelectedPatient.LoadMemoAsync);
        }

        private void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            addpatientframe.Navigate(typeof(AddPatient), null);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            addpatientframe.Navigate(typeof(AddPatient), ViewModel.SelectedPatient);
        }

        private async void Listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var memoid = Listview.SelectedItem;

            memoframe.Navigate(typeof(MemoDetailsForReport), memoid);

            if (AppWindow == null)
            {
                // Create a new window
                AppWindow = await AppWindow.TryCreateAsync();
                // Make sure we release the reference to this window, and release XAML resources, when it's closed
                AppWindow.Closed += delegate { AppWindow = null; appWindowFrame.Content = null; };
                // Navigate the frame to the page we want to show in the new window
                appWindowFrame.Navigate(typeof(report), memoid);
                // Attach the XAML content to our window
                ElementCompositionPreview.SetAppWindowContent(AppWindow, appWindowFrame);
            }

            // Now show the window
            await AppWindow.TryShowAsync();

            //memoframe.Navigate(typeof(report), memoid);
        }

    }
}
