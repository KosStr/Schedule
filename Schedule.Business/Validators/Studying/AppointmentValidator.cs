using FluentValidation;
using Schedule.Business.Validators.Base;
using Schedule.Core.Entities.Studying;
using Schedule.Database.Repository.Interfaces;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Business.Validators.Studying
{
    public class AppointmentValidator : ValidatorBase<Appointment>
    {
        public AppointmentValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleSet($"{Rules.Create}", () =>
            {
                RuleFor(i => i.Id).Empty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.IsOnline).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.IsCancelled).NotEmpty().WithMessage(Messages.InvalidInput);
            });
            RuleSet($"{Rules.Update}", () =>
            {
                RuleFor(i => i.Id).MustAsync(async (id, cancellation) => await unitOfWork.Repository<Appointment>().ExistAsync(i => i.Id == id, cancellation)).WithMessage(Messages.NonExistingId);
                RuleFor(i => i.IsOnline).NotEmpty().WithMessage(Messages.InvalidInput);
                RuleFor(i => i.IsCancelled).NotEmpty().WithMessage(Messages.InvalidInput);
            });
        }
    }
}
