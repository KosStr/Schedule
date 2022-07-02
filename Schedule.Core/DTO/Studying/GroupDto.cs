using Schedule.Core.DTO.Account;
using Schedule.Core.Entities.Studying;
using System;
using System.Collections.Generic;

namespace Schedule.Core.DTO.Studying
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
