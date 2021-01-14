using Domin.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Models;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class AccountViewModel : BindableBase
    {
        public AccountViewModel(Account acount = null)
        {
            Account = acount ?? new Account();

        }


        private bool _IsLoading = false;

        public bool Isloading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }



        public Account Account  { get; set; }


        public int AccountId
        {
            get => Account.AccountId;
            set
            {
                if (Account.AccountId != value)
                {
                    Account.AccountId = value;

                    OnPropertyChanged();
                }
            }
        }
        public string AccountName
        {
            get => Account.AccountName;
            set
            {
                if (Account.AccountName != value)
                {
                    Account.AccountName = value;

                    OnPropertyChanged();
                }
            }
        }

        public string AccountCode
        {
            get => Account.AccountCode;
            set
            {
                if (value != Account.AccountCode)
                {
                    Account.AccountCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddAccount => new RelayCommand<Account>(AddAccountAsync);

        public void AddAccountAsync(Account account)
        {
            var result =  App.Repository.Account.UpsertAsync(account);
       


        }

    }

}

