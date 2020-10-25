using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMemoRepository :IRepository<Memo>
    {



        Task<IEnumerable<Memo>> GetForPatientAsync(string id);

        Task<Memo> GetMemoAsync(string Id);
    }

    
}
