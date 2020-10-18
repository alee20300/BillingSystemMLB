using Microsoft.EntityFrameworkCore;
using Repository.SQL;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DbContextOptions<ApplicationContext> _dbOptions;

        public BillingRepository(DbContextOptionsBuilder<ApplicationContext> dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new ApplicationContext(_dbOptions))
            {
                db.Database.EnsureCreated();
            }
        }

        public IPatientRepository Patient => new PatientRepository(new ApplicationContext(_dbOptions));
        public IMemoRepository Memo => new MemoRepository(new ApplicationContext(_dbOptions));


    }
}
