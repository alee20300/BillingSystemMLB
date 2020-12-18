﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UwpApp.Configuration;
using UwpApp.Services.Infrastructure;
using UwpApp.Views.Login;
using ViewModels.Infrastructure.Common;
using ViewModels.ViewModels.Shell;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SplashScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExtendedSplash : Page
    {

        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private Windows.ApplicationModel.Activation.SplashScreen splashScreen; // Variable to hold the splash screen object.
        private Frame rootFrame;
        private IActivatedEventArgs activatedEventArgs;
        public ExtendedSplash(IActivatedEventArgs e, bool loadState)
        {
            this.InitializeComponent();

            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            splashScreen = e.SplashScreen;
            this.activatedEventArgs = e;

            if (splashScreen != null)
            {
                // Retrieve the window coordinates of the splash screen image.
                splashImageRect = splashScreen.ImageLocation;
            }

            Resize();
            rootFrame = new Frame();
            LoadDataAsync(this.activatedEventArgs);
        }


        private async void LoadDataAsync(IActivatedEventArgs e)
        {
            var activationInfo = ActivationService.GetActivationInfo(e);

            await Startup.ConfigureAsync();

            var shellArgs = new ShellArgs
            {
                ViewModel = activationInfo.EntryViewModel,
                Parameter = activationInfo.EntryArgs,
                UserInfo = await TryGetUserInfoAsync(e as IActivatedEventArgsWithUser)
            };

#if SKIP_LOGIN
            rootFrame.Navigate(typeof(MainShellView), shellArgs);
            var loginService = ServiceLocator.Current.GetService<ILoginService>();
            loginService.IsAuthenticated = true;
#else
            rootFrame.Navigate(typeof(LoginView), shellArgs);
#endif

            Window.Current.Content = rootFrame;

            Window.Current.Activate();

        }


        private void Resize()
        {
            if (this.splashScreen == null) return;

            // The splash image's not always perfectly centered. Therefore we need to set our image's position 
            // to match the original one to obtain a clean transition between both splash screens.

            this.splashImage.Height = this.splashScreen.ImageLocation.Height;
            this.splashImage.Width = this.splashScreen.ImageLocation.Width;

            this.splashImage.SetValue(Canvas.TopProperty, this.splashScreen.ImageLocation.Top);
            this.splashImage.SetValue(Canvas.LeftProperty, this.splashScreen.ImageLocation.Left);

            this.progressRing.SetValue(Canvas.TopProperty, this.splashScreen.ImageLocation.Top + this.splashScreen.ImageLocation.Height + 50);
            this.progressRing.SetValue(Canvas.LeftProperty, this.splashScreen.ImageLocation.Left + this.splashScreen.ImageLocation.Width / 2 - this.progressRing.Width / 2);
        }

        void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be fired in response to snapping, unsnapping, rotation, etc...
            if (splashScreen != null)
            {
                // Update the coordinates of the splash screen image.
                splashImageRect = splashScreen.ImageLocation;
                Resize();
            }
        }

        private async Task<UserInfo> TryGetUserInfoAsync(IActivatedEventArgsWithUser argsWithUser)
        {
            if (argsWithUser != null)
            {
                var user = argsWithUser.User;
                var userInfo = new UserInfo
                {
                    AccountName = await user.GetPropertyAsync(KnownUserProperties.AccountName) as String,
                    FirstName = await user.GetPropertyAsync(KnownUserProperties.FirstName) as String,
                    LastName = await user.GetPropertyAsync(KnownUserProperties.LastName) as String
                };
                if (!userInfo.IsEmpty)
                {
                    if (String.IsNullOrEmpty(userInfo.AccountName))
                    {
                        userInfo.AccountName = $"{userInfo.FirstName} {userInfo.LastName}";
                    }
                    //var pictureStream = await user.GetPictureAsync(UserPictureSize.Size64x64);
                    //if (pictureStream != null)
                    //{
                    //    userInfo.PictureSource = await BitmapTools.LoadBitmapAsync(pictureStream);
                    //}
                    return userInfo;
                }
            }
            return UserInfo.Default;
        }
    }
}
