using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Chat
{
    public class Message : AuditEntity
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public bool IsRead { get; set; }
    }
}
