using Domin.Models;
using Repository.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository:IRepository<Account>
    {
        Task<Account> GetAccountbyIdInt(int Id);
    }

    
}
