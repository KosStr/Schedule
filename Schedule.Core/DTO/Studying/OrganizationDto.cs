using System;
using System.Collections.Generic;

namespace Schedule.Core.DTO.Studying
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FacultyDto> Faculties { get; set; }
    }
}
