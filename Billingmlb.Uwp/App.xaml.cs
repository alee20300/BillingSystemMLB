using MvvmCross.Platforms.Uap.Core;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.Core;
using Billing.core;

namespace Billingmlb.Uwp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Billingmlbapp
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

        }
    }

    public abstract class Billingmlbapp : MvxApplication<MvxWindowsSetup<Billing.core.App>, Billing.core.App>
    {

    }

}
