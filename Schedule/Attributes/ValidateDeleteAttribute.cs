using FluentValidation.AspNetCore;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Attributes
{
    public class ValidateDeleteAttribute : CustomizeValidatorAttribute
    {
        public ValidateDeleteAttribute()
        {
            RuleSet = Rules.Delete;
        }
    }
}
