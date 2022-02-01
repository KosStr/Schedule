using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Token
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; }
        public DateTime ExpiryTime { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
