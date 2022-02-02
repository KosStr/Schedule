using System;

namespace Schedule.Core.DTO.Account
{
    public class AuthResult
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshExpiry { get; set; }
        public UserDto User { get; set; }

    }
}
