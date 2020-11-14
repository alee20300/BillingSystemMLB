using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class MemoRepository : BaseRepository<Memo>, IMemoRepository
    {
        ApplicationContext _db;
        public MemoRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Memo>> GetForPatientAsync(int id)=>
        
            await dbSet
                .Where(memo => memo.Patient.PatientId == id)
                .Include(order => order.MemoDetails)
                .ThenInclude(memodetail => memodetail.Service)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Memo> GetMemoAsync(int Id) =>
            await dbSet
            .Include(memo => memo.MemoDetails)
            .ThenInclude(memoDetail => memoDetail.Service)
            .AsNoTracking()
            .FirstOrDefaultAsync(memo => memo.MemoNumber == Id);

        public async Task<Memo> Update(Memo memo)
        {
            var existing = await dbSet.FirstOrDefaultAsync(_memo => _memo.MemoNumber == memo.MemoNumber);
            //var account = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == memo.Account.Id);
            

            if (null == existing)

            {
                memo.MemoNumber = 0;
                _db.Memos.Add(memo);

            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(memo);
            }
  
            _db.Update(memo.Patient);
            _db.Update(memo.Account);
            var state = (_db.ChangeTracker.Entries());
            await _db.SaveChangesAsync();
            return memo;
        }
    }
}
