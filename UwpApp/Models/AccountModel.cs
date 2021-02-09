using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Models
{
  public  class AccountModel
    {
        public AccountModel()
        {
        }

        public AccountModel(Account account)
        {
            AccountId = account.AccountId;
            AccountName = account.AccountName;
            AccountCode = account.AccountCode;
        }
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountCode { get; set; }

    }
}
