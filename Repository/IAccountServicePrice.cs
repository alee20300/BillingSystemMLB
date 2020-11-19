using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface  IAccountServicePrice :IRepository<AccountServicePrice>

    {
        AccountServicePrice GetAccountServicePrice(int acc, int ser);
    }
}
