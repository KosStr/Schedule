using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Database.SeedData
{
    internal class SeedTeacherSubject : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.HasData(
                new TeacherSubject() 
                { 
                    TeacherId = new Guid("2a8fd411-d328-42a7-adca-f8d58f14c84c"),
                    SubjectId = new Guid("792b026d-891e-4e1e-8d14-77e0a4584d49")
                },
                new TeacherSubject()
                {
                    TeacherId = new Guid("2a8fd411-d328-42a7-adca-f8d58f14c84c"),
                    SubjectId = new Guid("e1f903f9-112f-4514-8f16-209640022f2e")
                },
                new TeacherSubject()
                {
                    TeacherId = new Guid("db67f91d-5e59-48df-9b4a-d786480e09c6"),
                    SubjectId = new Guid("fb614104-6236-49cc-8811-9788bfcfb579")
                },
                new TeacherSubject()
                {
                    TeacherId = new Guid("12e05dcf-6b56-4105-bbb6-390752fa6873"),
                    SubjectId = new Guid("e4b3b428-eea4-4c74-bcfd-c710eacd94b6")
                },
                new TeacherSubject()
                {
                    TeacherId = new Guid("469ac11e-2dca-45cb-ae12-74d6e80b52ab"),
                    SubjectId = new Guid("0250c681-1e01-43a3-9098-a63f45bfeed5")
                }
            );
        }
    }
}
