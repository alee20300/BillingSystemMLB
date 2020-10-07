using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.WindowsUWP.Platform;
using Windows.UI.Xaml.Controls;


namespace Billing.UniversalWindows
{
   public class Setup :MvxWindowsSetup
    {
        public Setup(Frame rootFrame ) : base(rootFrame)
        {

        }

        protected override IMvxApplication CreateApp()
        {

            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
