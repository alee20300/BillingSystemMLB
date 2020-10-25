using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class MemoRepository : BaseRepository<Memo>, IMemoRepository
    {
        public MemoRepository(ApplicationContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Memo>> GetForPatientAsync(string id)=>
        
            await dbSet
                .Where(memo => memo.Patient.Id == id)
                .Include(order => order.MemoDetails)
                .ThenInclude(memodetail => memodetail.Service)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Memo> GetMemoAsync(string Id) =>
            await dbSet
            .Include(memo => memo.MemoDetails)
            .ThenInclude(memoDetail => memoDetail.Service)
            .AsNoTracking()
            .FirstOrDefaultAsync(memo => memo.MemoNumber == Id);
        
    }
}
