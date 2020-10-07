using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _db;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext db)
        {
            _db = db;
            dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }




        public async Task<IEnumerable<TEntity>> GetAsync(string Search)
        {
            throw new NotImplementedException();
        }



        public async Task<TEntity> GetAsync(Guid Id)
        {
            return await _db.Set<TEntity>().FindAsync(Id);
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
