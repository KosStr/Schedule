using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using StudyngTask = Schedule.Core.Entities.Studying.Task;

namespace Schedule.Business.Services.Implementations.Studying
{
    internal class TaskService : ServiceBase, ITaskService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public TaskService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(StudyngTask task, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<StudyngTask>().CreateAsync(task, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<StudyngTask>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        public async Task<TaskDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<StudyngTask>().GetFirstAsync(i => i.Id == id, i => new TaskDto
            {
                Id = i.Id,
                Description = i.Description,
                Title = i.Title,
                Appointment = i.Appointment
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(TaskDto task, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<StudyngTask>().GetFirstAsync(i => i.Id == task.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.Description = task.Description;
            entity.Title = task.Title;

            await UnitOfWork.Repository<StudyngTask>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
