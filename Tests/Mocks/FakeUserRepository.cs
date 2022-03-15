using Schedule.Core.Entities.Account;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Tests.Mocks
{
    public class FakeUserRepository : ISqlRepository<User>
    {
        private List<User> _users = new List<User>();

        public Task<User> CreateAsync(User entity, CancellationToken cancellationToken = default)
        {
            _users.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<User>> CreateManyAsync(IEnumerable<User> entities, CancellationToken cancellationToken = default)
        {
            _users.AddRange(entities);
            return Task.FromResult(entities);
        }

        public Task DeleteAsync(Expression<Func<User, bool>> condition, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<User, bool>> condition, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<User, bool>> condition, Expression<Func<User, TResult>> selector, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<User, bool>> condition, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetFirstAsync<TResult>(Expression<Func<User, bool>> condition, Expression<Func<User, TResult>> selector, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManyAsync(IEnumerable<User> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
