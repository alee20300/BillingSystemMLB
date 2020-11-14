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

        public DbSet<Country> Country { get; set; }
       

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

            modelBuilder.Entity<Memo>()
                .HasOne(p => p.Patient)
                .WithMany(m => m.Memos);
            modelBuilder.Entity<Atoll>()
                .HasData(new Atoll { Id=1, AtollName = "G DH" });
            modelBuilder.Entity<Island>()
                .HasData(new Island() {   AtollId = 1, Id=1, IslandName = "Thinadhoo" });
            modelBuilder.Entity<Catogory>()
                .HasData(new Catogory { Id=1, Name="Hematology" , CatogoryCode="HEME" });
            modelBuilder.Entity<Service>()
                .HasData(new Service() { Id=1, ServiceCode = "112", CatogoryId = 1, ICode="112", IsActive=true, LisCode="112", Rate=112, ServiceName="ESR" });
            modelBuilder.Entity<Country>()
                .HasData(new Country {Id=1, CountryName = "Maldives" });
            modelBuilder.Entity<Patient>()
                .HasData(new Patient() { AtollId=1, countryId=1 , Contact= "9702030",  CreatedBy="Ali" , Email="Alee20300@gmail.com", IslandId=1, DateOfBirth= DateTime.Now, Name="Ali Abdulla" , Sex="M", PermAddress="Sandalwood"  });
            
        }
    }
}
