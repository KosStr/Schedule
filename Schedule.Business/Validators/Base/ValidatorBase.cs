using FluentValidation;
using Schedule.Core.Entities.Base;
using Schedule.Database.Repository.Interfaces;

namespace Schedule.Business.Validators.Base
{
    public class ValidatorBase<T>: AbstractValidator<T> where T : class, ISqlEntity
    {
        public ValidatorBase(IUnitOfWork unitOfWork) 
        {
            var repository = unitOfWork.Repository<T>();
            ClassLevelCascadeMode = CascadeMode.Continue;
        } 
    }
}
