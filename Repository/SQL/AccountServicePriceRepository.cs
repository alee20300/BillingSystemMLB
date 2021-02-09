using Domin.Models;
using System.Linq;

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
