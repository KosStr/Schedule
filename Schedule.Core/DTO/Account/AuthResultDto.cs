using Schedule.Core.Enums;
using System;

namespace Schedule.Core.DTO.Account
{
    public class AuthResultDto
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshExpiry { get; set; }
        public ActionStatus Status { get; set; }
        public UserDto User { get; set; }

        public static AuthResultDto Fail => new AuthResultDto { Status = ActionStatus.Fail };
        public static AuthResultDto Success => new AuthResultDto { Status = ActionStatus.Success };
    }
}
