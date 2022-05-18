using FluentValidation.AspNetCore;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Attributes
{
    public class ValidateCreateAttribute: CustomizeValidatorAttribute
    {
        public ValidateCreateAttribute()
        {
            RuleSet = Rules.Create;
        }
    }
}
