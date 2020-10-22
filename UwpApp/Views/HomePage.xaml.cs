﻿using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.UserControls;
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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
       
        }

        public ShellViewModel ViewModel => App.ShellViewModel;
   
        
        private async void AutoSuggestBox_TextChangedAsync(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {

                if (string.IsNullOrEmpty(sender.Text))
                {
                    await DispatcherHelper.ExecuteOnUIThreadAsync(async ()=>
                        await ViewModel.GetPatientsListAsync());
                    sender.ItemTemplate = null;
                }
                else
                {

                    string[] parameters = sender.Text.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    sender.ItemsSource = ViewModel.Patients
                        .Where(patient => parameters.Any(Parameter =>
                          patient.IdCardNumber.StartsWith(Parameter, StringComparison.OrdinalIgnoreCase)))
                        //.Select
                        //(patient => patient.IdCardNumber)
                        ;
                   
                    
                }
                //Set the ItemsSource to be your filtered dataset
                //sender.ItemsSource = dataset;
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.


            ViewModel.SelectedPatient = (args.SelectedItem as FrameworkElement).DataContext as PatientViewModel;
            
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
    }
}
