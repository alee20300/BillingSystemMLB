using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(string Search);
        Task<TEntity> GetbyIdAsync(int Id);
        Task<TEntity> UpsertAsync(TEntity entity);

        Task<IEnumerable<TEntity>> UpsrBulk(IEnumerable<TEntity> entities);




    }
}
