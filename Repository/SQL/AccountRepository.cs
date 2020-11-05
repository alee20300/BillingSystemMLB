using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<Account> GetAccountbyIdInt(int Id)
        {
            return await dbSet.FirstOrDefaultAsync(account => account.Id == Id);
        }
    }
}
