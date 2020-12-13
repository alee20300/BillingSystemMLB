using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class CollectionSIteRepository : BaseRepository<CollectionSite>, ICollectionSiteRepository
    {
        public CollectionSIteRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
