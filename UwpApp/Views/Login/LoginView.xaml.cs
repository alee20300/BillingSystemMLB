﻿using UwpApp.Models;
using UwpApp.ViewModel.Authentication;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {

        public AuthenticationViewModel authenticationViewModel { get; set; }
        public LoginView()
        {
            this.InitializeComponent();
            authenticationViewModel = new AuthenticationViewModel();

        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            
            var rootframe = Window.Current.Content as Frame;

            try
            {
                AutorizeDetailModel result = await authenticationViewModel.Authenticate();

                if (result.IsAuthenticated == false)
                {
                    rootframe.Navigate(typeof(ShellView));
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            


            //if (result!= null)
            //{
            
            //}
            //else
            //{ }


        }
    }
}
