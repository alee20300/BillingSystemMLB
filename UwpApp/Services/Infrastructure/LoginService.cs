using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Infrastructure.Services;
using Windows.Security.Credentials;
using Windows.Storage.Streams;

namespace UwpApp.Services.Infrastructure
{
   public class LoginService: ILoginService

    {

        public LoginService(IMessageService messageService, IDialogService dialogService)
        {
            IsAuthenticated = false;
            MessageService = messageService;
            DialogService = dialogService;
        }

        public IMessageService MessageService { get; }
        public IDialogService DialogService { get; }

        public bool IsAuthenticated { get; set; }

       

        public Task<bool> SignInWithPasswordAsync(string userName, string password)
        {
            // Perform authentication here.
            // This sample accepts any user name and password.
            UpdateAuthenticationStatus(true);
            return Task.FromResult(true);
        }

        

        public void Logoff()
        {
            UpdateAuthenticationStatus(false);
        }

        private void UpdateAuthenticationStatus(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
            MessageService.Send(this, "AuthenticationChanged", IsAuthenticated);
        }

       

       

        private async Task<IBuffer> CreatePassportKeyCredentialAsync(string userName)
        {
            // Create a new KeyCredential for the user on the device
            var keyCreationResult = await KeyCredentialManager.RequestCreateAsync(userName, KeyCredentialCreationOption.ReplaceExisting);

            if (keyCreationResult.Status == KeyCredentialStatus.Success)
            {
                // User has autheniticated with Windows Hello and the key credential is created
                var credential = keyCreationResult.Credential;
                return credential.RetrievePublicKey();
            }
            else if (keyCreationResult.Status == KeyCredentialStatus.NotFound)
            {
                await DialogService.ShowAsync("Windows Hello", "To proceed, Windows Hello needs to be configured in Windows Settings (Accounts -> Sign-in options)");
            }
            else if (keyCreationResult.Status == KeyCredentialStatus.UnknownError)
            {
                await DialogService.ShowAsync("Windows Hello Error", "The key credential could not be created. Please try again.");
            }

            return null;
        }

        const int NTE_NO_KEY = unchecked((int)0x8009000D);
        const int NTE_PERM = unchecked((int)0x80090010);

        static private async Task<bool> TryDeleteCredentialAccountAsync(string userName)
        {
            try
            {
                //AppSettings.Current.WindowsHelloPublicKeyHint = null;
                await KeyCredentialManager.DeleteAsync(userName);
                return true;
            }
            catch (Exception ex)
            {
                switch (ex.HResult)
                {
                    case NTE_NO_KEY:
                        // Key is already deleted. Ignore this error.
                        break;
                    case NTE_PERM:
                        // Access is denied. Ignore this error. We tried our best.
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        break;
                }
            }
            return false;
        }

        static private Task<bool> RegisterPassportCredentialWithServerAsync(IBuffer publicKey)
        {
            // TODO:
            // Register the public key and attestation of the key credential with the server
            // In a real-world scenario, this would likely also include:
            //      - Certificate chain for attestation endorsement if available
            //      - Status code of the Key Attestation result : Included / retrieved later / retry type
            return Task.FromResult(true);
        }

    }
}
