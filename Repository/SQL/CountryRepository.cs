using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
