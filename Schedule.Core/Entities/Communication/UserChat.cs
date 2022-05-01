using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.Communication
{
    public class UserChat
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
