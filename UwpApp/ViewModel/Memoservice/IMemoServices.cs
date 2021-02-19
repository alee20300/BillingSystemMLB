using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.Memoservice
{
    public interface IMemoServices
    {
        Task<Memo> MakeMemo(Patient patient);

        Task<IEnumerable<Memo>> MakeBulkMemo(IEnumerable<Patient> patients);
        Task<Memo> SaveMemo(Memo memo);
        Task<IEnumerable<Memo>> SaveBulkMemo(IEnumerable<Memo> memos);
        IEnumerable<Service> GetServicesForSugesstion(string Query);
    }
}
