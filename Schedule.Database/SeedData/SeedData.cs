using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Database.SeedData
{
    internal static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SeedGroups());
            builder.ApplyConfiguration(new SeedSubjects());
            builder.ApplyConfiguration(new SeedUsers());
            builder.ApplyConfiguration(new SeedTeacherSubject());
        }
    }
}
