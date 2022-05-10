using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.General;
using System;

namespace Schedule.Core.DTO.Studying
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public User Student { get; set; }
        public Subject Subject { get; set; }
    }
}
