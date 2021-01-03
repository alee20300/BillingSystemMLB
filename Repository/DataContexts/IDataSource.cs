using Domin.Data;
using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.DataContexts
{
    public interface IDataSource : IDisposable
    {
        DbSet<DbVersion> DbVersion { get; }

        DbSet<Patient> Patients { get; }
        DbSet<Account> Accounts { get; }
        DbSet<AccountServicePrice> AccountServicePrices { get; }
        DbSet<Memo> Memos { get; }
        DbSet<Island> Islands { get; }
        DbSet<Atoll> Atolls { get; }
        DbSet<MemoDetail> MemoDetails { get; }

        DbSet<Country> Country { get; }


        DbSet<Service> Services { get; }

        DbSet<Invoice> Invoices { get; }

        DbSet<InvoiceDetail> InvoiceDetails { get; }

        DbSet<CollectionSite> collectionSites { get; }
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));



    }
}
