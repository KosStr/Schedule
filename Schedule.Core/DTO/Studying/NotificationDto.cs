using Schedule.Core.Entities.Account;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;

namespace Schedule.Core.DTO.Studying
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Message { get; set; }
        public NotificationPriority Priority { get; set; }
        public NotificationType Type { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
