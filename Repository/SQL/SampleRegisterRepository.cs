using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class SampleRegisterRepository : BaseRepository<SampleRegister>, ISampleRegisterRepository
    {
        public SampleRegisterRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
