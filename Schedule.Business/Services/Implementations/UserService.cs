using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Communication;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations
{
    internal class UserService : ServiceBase, IUserService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public UserService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<AppointmentGroup>().GetAsync(i => i.GroupId == currentUser.Value.GroupId, i => new AppointmentDto
            {
                Id = i.Appointment.Id,
                FromDate = i.Appointment.FromDate,
                DueDate = i.Appointment.DueDate,
                Link = i.Appointment.Link,
                Task = i.Appointment.Task,
                Teacher = i.Appointment.Teacher,
                Subject = i.Appointment.Subject,
                IsCancelled = i.Appointment.IsCancelled,
                IsOnline = i.Appointment.IsCancelled
            }, cancellationToken);
        }

        public Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return UnitOfWork.Repository<User>().GetFirstAsync(i => i.Id == id, i => new UserDto
            {
                Id = i.Id,
                Email = i.Email,
                FirstName = i.FirstName,
                LastName = i.LastName,
                GroupName = i.Group.Name,
                Role = i.Role
            }, cancellationToken);
        }

        public async Task<IEnumerable<ChatDto>> GetChatsAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<UserChat>().GetAsync(i => i.UserId == currentUser.Value.UserId, i => new ChatDto
            {
                Id = i.Chat.Id,
                Name = i.Chat.Name,
                Messages = i.Chat.Messages.Select(m => new Message
                {
                    Text = m.Text,
                    IsRead = m.IsRead, 
                    SenderId = m.SenderId, 
                    CreatedAt = m.CreatedAt,
                    ChatId = m.ChatId
                }),
                OrganizerId = i.Chat.OrganizerId,
                Participants = i.Chat.Participants.Select(p => new User
                {
                    Id = p.Id,
                    FirstName = p.FirstName, 
                    LastName = p.LastName,

                }),
            }, cancellationToken);
        }

        public async Task<IEnumerable<GradeDto>> GetGradesAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Grade>().GetAsync(i => i.StudentId == currentUser.Value.UserId, i => new GradeDto
            {
                Id = i.Id,
                Date = i.Date,
                Comment = i.Comment,
                Value = i.Value,
                Student = i.Student,
                Subject = i.Subject
            }, cancellationToken);
        }

        public async Task<IEnumerable<GradeDto>> GetSubjectGradesAsync(Guid subjectId, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Grade>().GetAsync(i => i.StudentId == currentUser.Value.UserId && i.SubjectId == SubjectId, i => new GradeDto
            {
                Id = i.Id,
                Date = i.Date,
                Comment = i.Comment,
                Value = i.Value,
                Student = i.Student,
                Subject = i.Subject
            }, cancellationToken);
        }

        public async Task<IEnumerable<UserDto>> GetGroupUsersAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<User>().GetAsync(i => i.GroupId == currentUser.Value.GroupId, i => new UserDto
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName
            }, cancellationToken);
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<UserNotification>().GetAsync(i => i.UserId == currentUser.Value.UserId, i => new NotificationDto
            {
                Id = i.Notification.Id,
                Message = i.Notification.Message,
                DueDate = i.Notification.DueDate,
                FromDate = i.Notification.FromDate,
                Priority = i.Notification.Priority,
                Type = i.Notification.Type
            }, cancellationToken);
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjectsAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<TeacherSubject>().GetAsync(i => i.SubjectId == currentUser.Value.UserId, i => new SubjectDto
            {
                Id = i.Subject.Id,
                Name = i.Subject.Name,
                Description = i.Subject.Description
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(UserDto user, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Id == user.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Phone = user.Phone;

            await UnitOfWork.Repository<User>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
