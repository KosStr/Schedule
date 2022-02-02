using Autofac;
using Microsoft.EntityFrameworkCore;
using Schedule.Database.Repository.Interfaces;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Database.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private readonly Lazy<DbContext> _context;
        private readonly ILifetimeScope _lifetimeScope;

        #endregion

        #region Constructor

        public UnitOfWork(Lazy<DbContext> context)
        {
            _context = context;
        }

        #endregion

        #region Interface Members

        public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return _context.Value.Database.BeginTransactionAsync(cancellationToken);
        }

        public void CommitTransaction()
        {
            if (_context.Value.Database.CurrentTransaction != null)
            {
                _context.Value.Database.CommitTransaction();
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Value.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                if (_context.Value.Database.CurrentTransaction != null)
                {
                    _context.Value.Database.RollbackTransaction();
                }
                throw;
            }
        }

        ISqlRepository<T> IUnitOfWork.Repository<T>()
        {
            return _lifetimeScope.Resolve<ISqlRepository<T>>(new NamedParameter("context", _context.Value));
        }

        public void Dispose()
        {
            if (_context.IsValueCreated)
            {
                _context.Value.Dispose();
            }
        }

        #endregion
    }
}
