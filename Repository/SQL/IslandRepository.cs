using Domin.Models;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class IslandRepository : BaseRepository<Island>, IIslandRepository
    {

        private readonly ApplicationContext _db;
        public IslandRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Island> manualupsert(Island island, Atoll atoll)
        {
            Island _island = new Island();
            _island = island;


            Atoll _atoll = new Atoll();
            _atoll = atoll;
            atoll.Islands.Add(_island);
            await _db.SaveChangesAsync();
            return _island;

        }


    }
}
