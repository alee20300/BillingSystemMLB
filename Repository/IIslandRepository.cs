using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IIslandRepository:IRepository<Island>
    {
        Task<Island> manualupsert(Island island,Atoll atoll);
    }
}
