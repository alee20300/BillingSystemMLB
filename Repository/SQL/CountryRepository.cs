using Domin.Models;

namespace Repository.SQL
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
