using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.Studying;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Studying
{
    public class AssignmentValidator : ValidatorBase<Assignment>
    {
        public AssignmentValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Title).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.DueDate).NotEmpty().GreaterThan(System.DateTime.Now).WithMessage(Messages.InvalidInput);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<Assignment>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
                RuleFor(i => i.Title).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.DueDate).NotEmpty().GreaterThan(System.DateTime.Now).WithMessage(Messages.InvalidInput);
            });
        }
    }
}
