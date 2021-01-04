using Microsoft.EntityFrameworkCore;
using Repository.SQL;


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

        public IAtollRepository Atoll => new AtollRepository(new ApplicationContext(_dbOptions));

        public IIslandRepository Island => new IslandRepository(new ApplicationContext(_dbOptions));

        public IDoctorRepository Doctor => new DoctorRepository(new ApplicationContext(_dbOptions));

        public IServiceRepository Service => new ServiceRepository(new ApplicationContext(_dbOptions));

        public IAccountRepository Account => new AccountRepository(new ApplicationContext(_dbOptions));

        public ICountryRepository Country => new CountryRepository(new ApplicationContext(_dbOptions));

        public IAccountServicePrice AccountServicePrice => new AccountServicePriceRepository(new ApplicationContext(_dbOptions));


        public ICollectionSiteRepository CollectionSite => new CollectionSIteRepository(new ApplicationContext(_dbOptions));

        public IInvoiceRepository Invoices => new InvoiceRepository(new ApplicationContext(_dbOptions));

        public IUserRepository Users => new UserRepository(new ApplicationContext(_dbOptions));

        public IRoleRepostitory Roles => new RoleRepository(new ApplicationContext(_dbOptions));

    }
}
