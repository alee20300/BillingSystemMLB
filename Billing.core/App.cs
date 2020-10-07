using Billing.core.ViewModel;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Billing.core
{
     public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            RegisterAppStart<PatientViewModel>();
        }
    }
}
