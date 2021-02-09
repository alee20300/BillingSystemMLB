using Domin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetServiceAsync(string search);


    }
}
