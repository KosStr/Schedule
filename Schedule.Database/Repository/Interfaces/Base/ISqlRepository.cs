using Schedule.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Database.Repository.Interfaces.Base
{
    public interface ISqlRepository<T> : IDisposable where T : class, ISqlEntity
    {
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<TResult> GetFirstAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        Task<int> GetCountAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
    }
}
