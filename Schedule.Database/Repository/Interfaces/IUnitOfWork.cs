using Schedule.Core.Entities.Base;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Database.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        ISqlRepository<T> Repository<T>() where T : class, ISqlEntity;
    }
}
