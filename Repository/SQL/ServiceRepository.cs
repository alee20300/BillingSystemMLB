﻿using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            service.ServiceCode.StartsWith(search)).AsNoTracking()
            .ToListAsync();
        }
    }
}
