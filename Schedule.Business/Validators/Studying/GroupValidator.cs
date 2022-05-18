using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.General;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Studying
{
    public class GroupValidator : ValidatorBase<Group>
    {
        public GroupValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Faculty).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Name).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i).MustAsync(async (group, cancellation) => !await unitOfWork.Repository<Group>().ExistAsync(i => i.Name == group.Name && i.Faculty == group.Faculty, cancellation))
                    .WithMessage(Messages.ExistingEntity);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<Group>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
                RuleFor(i => i.Faculty).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Name).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i).MustAsync(async (group, cancellation) => !await unitOfWork.Repository<Group>().ExistAsync(i => i.Name == group.Name && i.Faculty == group.Faculty, cancellation))
                    .WithMessage(Messages.ExistingEntity);
            });
        }
    }
}
