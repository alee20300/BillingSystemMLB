using Domin.Models;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountbyIdInt(string AccountName);
    }


}
