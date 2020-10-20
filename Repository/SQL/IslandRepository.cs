using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class IslandRepository : BaseRepository<Island>, IIslandRepository
    {
        public IslandRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
