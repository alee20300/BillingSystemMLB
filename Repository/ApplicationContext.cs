using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domin.Models;
using Domin.Configuration;

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
       

        public DbSet<Service> Services { get; set; }
            



        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new MemoConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountServicePriceConfiguration());
            modelBuilder.ApplyConfiguration(new IslandConfiguration());
            modelBuilder.ApplyConfiguration(new AtollConfiguration());
            modelBuilder.ApplyConfiguration(new MemoDetailConfiguration());



        }
    }
}
