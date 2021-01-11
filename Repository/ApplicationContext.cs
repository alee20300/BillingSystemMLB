using Domin.Configuration;
using Domin.Data;
using Domin.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationContext : DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {


        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountServicePrice> AccountServicePrices { get; set; }
        public DbSet<Memo> Memos { get; set; }
        public DbSet<Island> Islands { get; set; }
        public DbSet<Atoll> Atolls { get; set; }
        public DbSet<MemoDetail> MemoDetails { get; set; }

        public DbSet<Country> Country { get; set; }


        public DbSet<Service> Services { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<CollectionSite> collectionSites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<AutorizeDetail> AutorizeDetails { get; set; }

        public DbSet<UsernameAndHash> UsernameAndHashes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new MemoConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountServicePriceConfiguration());
            modelBuilder.ApplyConfiguration(new IslandConfiguration());
            modelBuilder.ApplyConfiguration(new AtollConfiguration());
            modelBuilder.ApplyConfiguration(new MemoDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CollectionSiteConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentDetailConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
