using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations.Studying
{
    internal class GroupService : ServiceBase, IGroupService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public GroupService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(Group group, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Group>().CreateAsync(group, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Group>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        public async Task<GroupDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Group>().GetFirstAsync(i => i.Id == id, i => new GroupDto
            {
                Id = i.Id,
                Name = i.Name,
                Faculty = i.Faculty,
                Assignments = i.Assignments,
                Appointments = i.Appointments,
            }, cancellationToken);
        }

        public async Task<IEnumerable<GroupDto>> GetByFacultyId(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Group>().GetAsync(i => i.FacultyId == currentUser.Value.FacultyId, i => new GroupDto
            {
                Id = i.Id,
                Name = i.Name,
                Users = i.Users.Select(i => new UserDto
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName
                })
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(GroupDto group, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<Group>().GetFirstAsync(i => i.Id == group.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.Name = group.Name;
            entity.Faculty = group.Faculty;

            await UnitOfWork.Repository<Group>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
