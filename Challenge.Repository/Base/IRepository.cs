using Challenge.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        Task<T> GetById(int id);
        Task<T> GetById(int id, Expression<Func<T, object>> include);
        Task<List<T>> GetByIds(int[] ids);
        Task<List<T>> GetList(CancellationToken cancellationToken = default);
        Task<List<T>> GetList(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<T>> GetListInclude(Expression<Func<T, object>> include, CancellationToken cancellationToken = default);
        Task<List<T>> GetListInclude(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include, CancellationToken cancellationToken = default);
    }
}
