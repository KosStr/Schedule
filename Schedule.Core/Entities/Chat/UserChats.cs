using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.Chat
{
    public class UserChats
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
