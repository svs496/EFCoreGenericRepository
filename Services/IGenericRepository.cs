using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductAppCore2.Services
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);

        IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes);


        TEntity GetByIdWithInclude(int id, params Expression<Func<TEntity, object>>[] includes);
    }
}
