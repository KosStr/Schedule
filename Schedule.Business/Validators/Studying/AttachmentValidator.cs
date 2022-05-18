using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.Studying;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Studying
{
    public class AttachmentValidator : ValidatorBase<Attachment>
    {
        public AttachmentValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<Attachment>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
            });
        }
    }
}
