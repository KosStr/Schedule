using Schedule.Core.Entities.Base;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Database.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        ISqlRepository<T> Sql<T>() where T : class, ISqlEntity;
    }
}
