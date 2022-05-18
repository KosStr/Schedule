using FluentValidation.AspNetCore;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Attributes
{
    public class ValidateUpdateAttribute : CustomizeValidatorAttribute
    {
        public ValidateUpdateAttribute()
        {
            RuleSet = Rules.Create;
        }
    }
}
