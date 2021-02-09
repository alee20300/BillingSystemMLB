using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUsernameAndHashRepository : IRepository<UsernameAndHash>
    {

      Task<UsernameAndHash> GetUsernameAndHash(string username);
    }
}
