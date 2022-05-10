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
    internal class GradeService : ServiceBase, IGradeService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public GradeService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public async Task<ActionStatus> CreateAsync(Grade grade, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Grade>().CreateAsync(grade, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        public async Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await UnitOfWork.Repository<Grade>().DeleteAsync(i => i.Id == id, cancellationToken);
            await UnitOfWork.SaveChangesAsync();
            return ActionStatus.Success;
        }

        public async Task<GradeDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Grade>().GetFirstAsync(i => i.Id == id, i => new GradeDto
            {
                Id = i.Id,
                Comment = i.Comment,
                Date = i.Date,
                Student = i.Student,
                Subject = i.Subject,
                Value = i.Value
            }, cancellationToken);
        }

        public async Task<ActionStatus> UpdateAsync(GradeDto grade, CancellationToken cancellationToken = default)
        {
            var entity = await UnitOfWork.Repository<Grade>().GetFirstAsync(i => i.Id == grade.Id, i => i, cancellationToken);
            if (entity == null)
            {
                return ActionStatus.NoAccess;
            }

            entity.Comment = grade.Comment;
            entity.Value = grade.Value;
            entity.Date = grade.Date;

            await UnitOfWork.Repository<Grade>().UpdateAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return ActionStatus.Success;
        }

        #endregion
    }
}
