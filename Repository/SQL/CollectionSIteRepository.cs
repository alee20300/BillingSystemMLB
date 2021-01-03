using Domin.Models;

namespace Repository.SQL
{
    public class CollectionSIteRepository : BaseRepository<CollectionSite>, ICollectionSiteRepository
    {
        public CollectionSIteRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
