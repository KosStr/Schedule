using Schedule.Core.Entities.Studying;
using System;

namespace Schedule.Core.DTO.Studying
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Appointment Appointment { get; set; }
    }
}
