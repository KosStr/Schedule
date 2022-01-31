using Microsoft.EntityFrameworkCore;
using Schedule.Core.Entities.Base;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Database.Repository.Implementations.Base
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class, ISqlEntity
    {
        #region Properties

        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;
        // current user prop to finish

        #endregion

        #region Constructor

        public SqlRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        #endregion

        #region Interface Members

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<IEnumerable<T>> CreateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _set.AddRangeAsync(entities, cancellationToken);
            return entities;
        }

        public Task DeleteAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            var entities = _set.Where(condition);
            _set.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return _set.AnyAsync(condition, cancellationToken);
        }

        public Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_set.Where(condition).Select(selector).AsEnumerable());
        }

        public Task<int> GetCountAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return _set.CountAsync(condition, cancellationToken);
        }

        public Task<TResult> GetFirstAsync<TResult>(Expression<Func<T, bool>> condition, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
        {
            return _set.Where(condition).Select(selector).FirstOrDefaultAsync(cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _set.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _set.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion
    }
}
