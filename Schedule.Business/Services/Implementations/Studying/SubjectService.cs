using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations.Studying
{
    internal class SubjectService : ServiceBase, ISubjectService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public SubjectService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Subject>().CreateAsync(subject, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Subject>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        public async Task<SubjectDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Subject>().GetFirstAsync(i => i.Id == id, i => new SubjectDto
            {
                Id = i.Id,
                Description = i.Description,
                Name = i.Name
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(SubjectDto subject, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<Subject>().GetFirstAsync(i => i.Id == subject.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.Description = subject.Description;
            entity.Name = subject.Name;

            await UnitOfWork.Repository<Subject>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
