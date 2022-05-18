using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.General;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Studying
{
    public class GradeValidator : ValidatorBase<Grade>
    {
        public GradeValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Date).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Value).NotEmpty().WithMessage(Messages.InvalidInput);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<Grade>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
                RuleFor(i => i.Date).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Value).NotEmpty().WithMessage(Messages.InvalidInput);
            });
        }
    }
}
