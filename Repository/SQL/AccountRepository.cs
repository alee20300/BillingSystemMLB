using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
