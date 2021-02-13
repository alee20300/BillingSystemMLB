using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Report
{
   public interface IReportingService
    {
        Task GenerateMemo(Memo memo);
        Task GenerateInvoice();
        Task GenerateDailySummary();





    }
}
