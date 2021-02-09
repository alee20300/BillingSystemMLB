using Domin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class UsernameAndHashRepository : BaseRepository<UsernameAndHash>, IUsernameAndHashRepository
    {
        public UsernameAndHashRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<UsernameAndHash> GetUsernameAndHash(string username)
        {
            return await dbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
