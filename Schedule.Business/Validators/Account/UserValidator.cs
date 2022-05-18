using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.Account;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Account
{
    public class UserValidator : ValidatorBase<User>
    {
        public UserValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Email).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.FirstName).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.LastName).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Phone).NotEmpty().Length(13).WithMessage(Messages.InvalidInput);
                RuleFor(i => i).MustAsync(async (user, cancellation) => !await unitOfWork.Repository<User>().ExistAsync(i => i.Email == user.Email || i.Phone == user.Phone, cancellation))
                    .WithMessage(Messages.ExistingEntity);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<User>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
                RuleFor(i => i.Email).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.FirstName).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.LastName).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i.Phone).NotEmpty().MaximumLength(50).WithMessage(Messages.InvalidInput);
                RuleFor(i => i).MustAsync(async (user, cancellation) => !await unitOfWork.Repository<User>().ExistAsync(i => i.Email == user.Email || i.Phone == user.Phone && i.Id != user.Id, cancellation))
                    .WithMessage(Messages.ExistingEntity);
            });
        }
    }
}
