using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository

    {
        public ServiceRepository(ApplicationContext db) : base(db)
        {
        }


        public async Task<IEnumerable<Service>> GetServiceAsync(string search)
        {
            return await dbSet.Where(service =>
            service.ServiceName.StartsWith(search) ||
            service.LisCode.StartsWith(search) ||
            service.ServiceCode.StartsWith(search))
            .ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetServiceswithTracking()
        {
            return await dbSet.Include(ap=>ap.AccountServicePrices).ToListAsync();
        }
    }
}
