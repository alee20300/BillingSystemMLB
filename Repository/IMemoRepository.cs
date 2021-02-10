﻿using Domin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UwpApp.Models;

namespace Repository
{
    public interface IMemoRepository : IRepository<Memo>
    {



        Task<IEnumerable<Memo>> GetForPatientAsync(int id);

        Task<Memo> GetMemoAsync(int Id);
        //Task<Memo> Update(Memo memo);
        Memo getreposrt(int MemoId);

        IEnumerable<DailySummaryModel> GetDailySummary(DateTime dateTime);

        Task<IEnumerable<Memo>> GetMemoForInvoice(DateTimeOffset from, DateTimeOffset to, int accountId);
    }




}
