using Microsoft.AspNetCore.Authorization;
using Schedule.Core.Enums;
using System;
using System.Linq;

namespace Schedule.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PolicyAttribute : AuthorizeAttribute
    {
        public PolicyAttribute(params Role[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
