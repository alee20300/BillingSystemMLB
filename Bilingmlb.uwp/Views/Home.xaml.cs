﻿using Billing.core.ViewModel;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bilingmlb.uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    [MvxViewFor(typeof(PatientViewModel))]
    public sealed partial class Home : MvxWindowsPage
    {
        public Home()
        {
            this.InitializeComponent();
        }
    }
}
