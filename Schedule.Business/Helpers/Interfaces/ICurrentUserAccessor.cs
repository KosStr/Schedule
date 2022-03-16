using Schedule.Core.Enums;
using System;

namespace Schedule.Business.Helpers.Interfaces
{
    public interface ICurrentUserAccessor
    {
        Guid? Id { get; }
        string Email { get; }
        Role? Role { get; }
    }

}
