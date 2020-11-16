using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class AtollRepository : BaseRepository<Atoll>, IAtollRepository
    {
        ApplicationContext _db;
        public AtollRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Atoll> GetbyintIdAsync(int Id)
        {
            
            return await dbSet.FirstOrDefaultAsync(atoll=>atoll.AtollId ==Id );
        }

        public async Task<Atoll> Update(Atoll atoll)
        {
            var existing = await dbSet.FirstOrDefaultAsync(_atoll => _atoll.AtollId == atoll.AtollId);
            if (null==existing )

            {
                dbSet.Add(existing);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(atoll);  
            }

            await _db.SaveChangesAsync();
            return atoll;
        }
    }
}
