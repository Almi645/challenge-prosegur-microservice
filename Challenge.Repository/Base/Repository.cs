using Challenge.Repository.Context;
using Challenge.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly DatabaseContext dbContext;

        public Repository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            var result = await dbContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById(int id, Expression<Func<T, object>> include)
        {
            return await dbContext.Set<T>().Include(include).FirstOrDefaultAsync(i => i.id == id);
        }

        public Task<List<T>> GetByIds(int[] ids)
        {
            return dbContext.Set<T>().Where(m => ids.Contains(m.id)).ToListAsync();
        }

        public Task<List<T>> GetList(CancellationToken cancellationToken = default)
        {
            return dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var query = dbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync(cancellationToken);
            return query;
        }

        public Task<List<T>> GetListInclude(Expression<Func<T, object>> include, CancellationToken cancellationToken = default)
        {
            return dbContext.Set<T>().Include(include).AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<List<T>> GetListInclude(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include, CancellationToken cancellationToken = default)
        {
            return dbContext.Set<T>().Where(expression).Include(include).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
