using Schedule.Core.Enums;
using System;

namespace Schedule.Core.DTO.General
{
    public class NotificationDto
    {
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Message { get; set; }
        public NotificationPriority Priority { get; set; }
    }
}
