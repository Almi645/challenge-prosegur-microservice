using Challenge.Repository.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<IDbContextTransaction> BeginTransactionAsync();

        #region properties

        #endregion
    }
}
