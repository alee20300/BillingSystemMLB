﻿using UwpApp.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.UserControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPatient : Page
    {
        public StaticData IAviewModel { get; set; }
        public PatientViewModel patientViewModel { get; set; } = new PatientViewModel();
        public AddPatient()
        {
            this.InitializeComponent();
            DataContext = patientViewModel;
            IAviewModel = new StaticData();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                patientViewModel = new PatientViewModel
                {
                    IsNewCustomer = true,


                };
            }
            else
            {
                patientViewModel = App.ShellViewModel.SelectedPatient;
            }
        }

        private void Atoll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            IAviewModel.UpdateIslands(sender.ToString());
        }
    }
}
