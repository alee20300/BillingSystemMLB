using Domin.Data;
using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UwpApp.Models;

namespace Repository.SQL
{
    public class MemoRepository : BaseRepository<Memo>, IMemoRepository
    {
        ApplicationContext _db;
        public MemoRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<DailySummaryModel> GetDailySummary(DateTime dateTime)
        {
            var p = dbSet.Join(_db.MemoDetails,
                m => m.MemoId,
                 md => md.MemoId,
             (m, md) =>
             new DailySummaryModel {

                 ServiceName = md.Service.ServiceName,
                 Qty = md.Qty,


             } )
                .AsNoTracking()
                
                .AsEnumerable();
            return p;
        }

        public async Task<IEnumerable<Memo>> GetForPatientAsync(int id) =>

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
            .Include(m => m.MemoDetails)
            .ThenInclude(p=>p.PaymentDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(memo => memo.MemoId == Id);

        public async Task<IEnumerable<Memo>> GetMemoForInvoice(DateTimeOffset from, DateTimeOffset to, int Account)
        {

            //return await dbSet.Where(m => m.MemoDate >= from && m.MemoDate <= to && m.IsPaid==false)
            //    .Include(memo => memo.MemoDetails).ToListAsync();

            return await dbSet.Where(m => m.MemoDate >= from && m.MemoDate <= to && m.IsPaid == false)
                .Include(m => m.PaymentSign)
                .Include(n => n.MemoDetails)
                .ThenInclude(o => o.PaymentDetails).ToListAsync();

                


            //return (IEnumerable<Memo>)await dbSet.Where(m => m.MemoDate >= from && m.MemoDate <= to)

            //    .Select(s => new
            //    {
            //        MemoId = s.MemoId,
            //        MemoDate = s.MemoDate,
            //        PatientName = s.PatientName,
            //        Address = s.Address,
            //        Rate = s.Rate,

            //        ispaid = s.IsPaid,
            //        MemoDetail = s.MemoDetails
            //    .Select(m => new
            //    {
            //        MemoDetailId = m.MemoDetailId,
            //        Qty = m.Qty,
            //        Service = m.Service,

            //        PaymentDetail = m.PaymentDetails
            //        .Select(a => new
            //        {
            //            PaymentId = a.PaymentId,
            //            Ammount = a.Amount,
            //            Account = a.Account
            //        }).Where(a => a.Account.AccountId == Account)
            //    })
            //    }).Where(m => m.ispaid == false).ToListAsync();


        }

        public Memo getreposrt(int MemoId)
        {
            return dbSet.Include(m => m.Patient)
                .Include(m => m.MemoDetails)
                .ThenInclude(s => s.Service)
               .Include(m => m.MemoDetails)
            .ThenInclude(p => p.PaymentDetails)
            .
                FirstOrDefault(m => m.MemoId == MemoId)



               ;
        }



       

        //public async Task<Memo> Update(Memo memo)
        //{
        //    var existing = await dbSet.Include(p => p.Patient).Include(m => m.MemoDetails)
        //        .FirstOrDefaultAsync(_memo => _memo.MemoId == memo.MemoId);
        //    //var account = await _db.Accounts.FirstOrDefaultAsync(a => a.Id == memo.Account.Id);

        //    var state1 = (_db.ChangeTracker.Entries());
        //    if (null == existing)

        //    {
        //        memo.PatientId = 0;
        //        memo.Patient.PatientId = 0;
        //        memo.MemoId = 0;
        //        memo.Account.AccountId = 0;
        //        _db.Memos.Add(memo);

        //    }
        //    else
        //    {
        //        _db.Entry(existing).CurrentValues.SetValues(memo);
        //    }

        //    //_db.Update(memo.Patient);


        //    var state = (_db.ChangeTracker.Entries());
        //    await _db.SaveChangesAsync();
        //    return memo;
        //}
    }
}
