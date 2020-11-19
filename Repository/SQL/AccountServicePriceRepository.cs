using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.SQL
{
    public class AccountServicePriceRepository : BaseRepository<AccountServicePrice>, IAccountServicePrice
    {
        public AccountServicePriceRepository(ApplicationContext db) : base(db)
        {
        }

        public AccountServicePrice GetAccountServicePrice(int acc, int ser)
        {
            return dbSet.Where(a => a.AccountId == acc)
                 .FirstOrDefault(s => s.ServiceId == ser);
                
        }
    }
}
