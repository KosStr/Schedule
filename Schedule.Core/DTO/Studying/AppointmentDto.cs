using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
using System;

namespace Schedule.Core.DTO.Studying
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsOnline { get; set; }
        public string Link { get; set; }
        public Subject Subject { get; set; }
        public User Teacher { get; set; }
        public Task Task { get; set; }
    }
}
