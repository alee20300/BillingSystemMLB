using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository

    {
        public ServiceRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
