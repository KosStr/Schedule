using System;
using System.Collections.Generic;

namespace Schedule.Core.DTO.Studying
{
    public class FacultyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
