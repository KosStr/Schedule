using Schedule.Core.Enums;
using System;

namespace Schedule.Core.DTO.Account
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public Role Role { get; set; }
    }
}
