using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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




        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity,bool>> match)
        {
            return await _db.Set<TEntity>().Where(match).ToListAsync();
          
                
        }



        public async Task<TEntity> GetbyIdAsync(string Id)
        {
            return await _db.Set<TEntity>().FindAsync(Id);
        }

        public Task<IEnumerable<TEntity>> GetAsync(string Search)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
