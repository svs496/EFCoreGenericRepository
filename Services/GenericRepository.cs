using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppCore2.Data;

namespace ProductAppCore2.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ProductDBContext _context;

        //private DbSet<TEntity> dbSet;

        public GenericRepository(ProductDBContext context)
        {
            _context = context;
           // dbSet = _context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            return includes.Aggregate(query, (q, w) => q.Include(w));

        }

        public async Task<IEnumerable<TEntity>>GetAll()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

    
        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public TEntity GetByIdWithInclude(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            var result = includes.Aggregate(query, (q, w) => q.Include(w));

            return result.FirstOrDefault(p => p.Id == id);
        }


    }
}
