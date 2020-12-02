using BoldReports.UI.Xaml;
using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using UwpApp.UserControls;
using UwpApp.ViewModel;
using UwpApp.ViewModel.ReportsViewModel;

using Windows.ApplicationModel.Activation;
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
    public sealed partial class HomePage : Page
    {

        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += ReportViewerPage_Loaded;

        }
        public Reports Reports { get; set; } = new Reports();

       
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
        private async  void AutoSuggestBox_TextChangedAsync(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
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

        private void Button_Click(object sender, RoutedEventArgs e)=>
        
            Frame.Navigate(typeof(AddMemo),ViewModel.SelectedPatient.Patient);

        private void loadbtn_Click(object sender, RoutedEventArgs e)
        {
           Task.Run( ViewModel.SelectedPatient.LoadMemoAsync);
        }

        private void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            addpatientframe.Navigate(typeof(AddPatient), null);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            addpatientframe.Navigate(typeof(AddPatient), ViewModel.SelectedPatient);
        }
    }
}
