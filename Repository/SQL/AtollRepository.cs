using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class AtollRepository : BaseRepository<Atoll>, IAtollRepository
    {
        public AtollRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
