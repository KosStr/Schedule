using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations.Studying
{
    internal class AppointmentService : ServiceBase, IAppointmentService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public AppointmentService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Appointment>().CreateAsync(appointment, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Appointment>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        public async Task<AppointmentDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Appointment>().GetFirstAsync(i => i.Id == id, i => new AppointmentDto
            {
                Id = i.Id,
                FromDate = i.FromDate,
                DueDate = i.DueDate,
                IsOnline = i.IsOnline,
                IsCancelled = i.IsCancelled,
                Link = i.Link,
                Subject = i.Subject,
                Task = i.Task,
                Teacher = i.Teacher
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(AppointmentDto appointment, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<Appointment>().GetFirstAsync(i => i.Id == appointment.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.FromDate = appointment.FromDate;
            entity.DueDate = appointment.DueDate;
            entity.IsOnline = appointment.IsOnline;
            entity.IsCancelled = appointment.IsCancelled;
            entity.Link = appointment.Link;

            await UnitOfWork.Repository<Appointment>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
