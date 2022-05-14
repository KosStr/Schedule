using Schedule.Business.Services.Interfaces;
using Schedule.Core.Enums;
using System;

namespace Schedule.Business.Helpers.Interfaces
{
    public interface ICurrentUser
    {
        Guid? UserId { get; }
        Guid? GroupId { get; }
        string Email { get; }
        Role? Role { get; }
    }
}
