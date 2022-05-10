using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Communication
{
    public class UserChat: ISqlEntity
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
