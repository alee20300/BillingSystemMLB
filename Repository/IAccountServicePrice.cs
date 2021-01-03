using Domin.Models;

namespace Repository
{
    public interface IAccountServicePrice : IRepository<AccountServicePrice>

    {
        AccountServicePrice GetAccountServicePrice(int acc, int ser);
    }
}
