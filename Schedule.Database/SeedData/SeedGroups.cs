using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using System;

namespace Schedule.Database.SeedData
{
    internal class SeedGroups : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData(
                new Group()
                {
                    Id = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd"),
                    Name = "PMO-41",
                    Faculty = Core.Enums.Faculty.AppliedMathematicsAndInformatics
                },
                new Group()
                {
                    Id = new Guid("0b22c341-cdfc-422c-a014-7e22e29d6c8b"),
                    Name = "PMI-43",
                    Faculty = Core.Enums.Faculty.AppliedMathematicsAndInformatics
                },
                new Group()
                {
                    Id = new Guid("6ec87e45-1a07-496b-a2df-7cc1b8d8e1e1"),
                    Name = "PMI-45",
                    Faculty = Core.Enums.Faculty.AppliedMathematicsAndInformatics
                },
                new Group()
                {
                    Id = new Guid("d80a3de5-29d6-4b7a-97c3-6b46925ec669"),
                    Name = "PMI-41",
                    Faculty = Core.Enums.Faculty.AppliedMathematicsAndInformatics
                }
            );
        }
    }
}
