using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<Account> GetAccountbyIdInt(string AccountName)
        {
            return await dbSet
                //.AsNoTracking()
                .FirstOrDefaultAsync(account => account.AccountName == AccountName);
        }
    }
}
