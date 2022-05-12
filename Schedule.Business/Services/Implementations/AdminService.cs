using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Entities.Account;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations
{
    internal class AdminService: ServiceBase, IAdminService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public AdminService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<User>().DeleteAsync(i => i.Id == userId, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        #endregion
    }
}
