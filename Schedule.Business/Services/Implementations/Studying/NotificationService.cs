using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
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
    internal class NotificationService : ServiceBase, INotificationService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public NotificationService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(NotificationDto notification, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Notification>().CreateAsync(new Notification
            {
                FromDate = notification.FromDate,
                DueDate = notification.DueDate,
                Message = notification.Message,
                Priority = notification.Priority,
                Type = notification.Type,
                UserNotifications = notification.Users.Select(i => new UserNotification
                {
                    UserId = i.Id
                }).ToList()
            }, cancellationToken);

            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Notification>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<NotificationDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Notification>().GetFirstAsync(i => i.Id == id, i => new NotificationDto
            {
                Id = i.Id,
                DueDate = i.DueDate,
                FromDate = i.FromDate,
                Message = i.Message,
                Priority = i.Priority,
                Type = i.Type,
                Users = i.Users
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(NotificationDto notification, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<Notification>().GetFirstAsync(i => i.Id == notification.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.Message = notification.Message;
            entity.Priority = notification.Priority;
            entity.Type = notification.Type;
            entity.FromDate = notification.FromDate;
            entity.DueDate = notification.DueDate;

            await UnitOfWork.Repository<Notification>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<IEnumerable<NotificationDto>> GetByFacultyAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<UserNotification>().GetAsync(i => i.User.Group.FacultyId == currentUser.Value.FacultyId, i => new NotificationDto
            {
                Id = i.Notification.Id,
                FromDate = i.Notification.FromDate,
                DueDate = i.Notification.DueDate,
                Message = i.Notification.Message,
                Priority = i.Notification.Priority,
                Type = i.Notification.Type
            }, cancellationToken);
        }

        #endregion
    }
}
