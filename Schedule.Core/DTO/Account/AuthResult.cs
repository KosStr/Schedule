using System;

namespace Schedule.Core.DTO.Account
{
    public class AuthResult
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public UserDto User { get; set; }

    }
}
