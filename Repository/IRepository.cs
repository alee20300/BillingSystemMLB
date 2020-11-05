using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  interface IRepository<TEntity> where TEntity : class 
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(string Search);
        Task<TEntity> GetbyIdAsync(string Id);
        Task<TEntity> UpsertAsync(TEntity entity);

        


    }
}
