using Domin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class AutorizeDetailRepository : BaseRepository<AutorizeDetail>, IAthorizeDetailRepository
    {
        public AutorizeDetailRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<AutorizeDetail> GetauthorrizedData(string username)
        {
           
                return await dbSet.FirstOrDefaultAsync(u => u.User.UserName == username);
           
        }
    }
}
