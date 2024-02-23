using Challenge.Repository.Context;
using Challenge.Repository.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new Repository<T>(dbContext);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await dbContext.Database.BeginTransactionAsync();
        }

        #region repositories

        #endregion
    }
}
