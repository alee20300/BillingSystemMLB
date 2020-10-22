using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
   public class AccountViewModel : BindableBase
    {
        public AccountViewModel(Account acount=null)
        {
            Account = acount ?? new Account();

        }


        private bool _IsLoading = false;

        public bool Isloading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }

        private Account _account;

        public Account Account
        {
            get => _account;
            set {
                if (_account!=value)
                {
                    _account = value;
                    OnPropertyChanged(string.Empty);
                }
            
            }
        }

        public int id
        {
            get => Account.Id;
            set
            {
                if (_account.Id != value)
                {
                    _account.Id = value;

                    OnPropertyChanged();
                }
            }
        }
        public string AccountName
        {
            get => Account.AccountName;
            set
            {
                if (_account.AccountName != value)
                {
                    _account.AccountName = value;

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

    }

}
