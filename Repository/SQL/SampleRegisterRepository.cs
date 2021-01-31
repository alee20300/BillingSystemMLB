using Domin.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class SampleRegisterRepository : BaseRepository<SampleRegister>, ISampleRegisterRepository
    {
        public SampleRegisterRepository(ApplicationContext db) : base(db)
        {


        }

        public async Task<IEnumerable<SampleRegister>> getregforsearch(string Query)
        {

            return await dbSet.Where(SampleRegister =>
            SampleRegister.SampleNumber.StartsWith(Query) ||
            SampleRegister.RecivedBy.Contains(Query))
                .AsNoTracking()
                .ToListAsync();


        }

       
    }
}
