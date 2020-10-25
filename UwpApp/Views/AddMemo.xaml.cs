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
            var id = (string)e.Parameter;
            var patient = App.ShellViewModel.Patients.Where(pati => pati.Patient.Id == id).FirstOrDefault();

            if (patient != null)
            {
                // Order is a new order
                ViewModel = new MemoViewModel(new Memo(patient.Patient));
            }
            else
            {
                // Order is an existing order.
                var memo = await App.Repository.Memo.GetMemoAsync(id);
                ViewModel = new MemoViewModel(memo);
            }

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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
