using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.General;
using System;

namespace Schedule.Database.SeedData
{
    internal class SeedSubjects : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasData(
                new Subject()
                {
                    Id = new Guid("792b026d-891e-4e1e-8d14-77e0a4584d49"),
                    Name = "Programming on C++",
                    Description = "C ++ - general purpose programming language with support for several programming paradigms: object-oriented, general, procedural, etc."
                },
                new Subject()
                {
                    Id = new Guid("fb614104-6236-49cc-8811-9788bfcfb579"),
                    Name = "Programming with using .NET platform",
                    Description = ".NET is a software technology offered by Microsoft as a platform for creating both regular applications and web applications"
                },
                new Subject()
                {
                    Id = new Guid("e4b3b428-eea4-4c74-bcfd-c710eacd94b6"),
                    Name = "Dynamic models in the economy",
                    Description = "Dynamic economic models typically arise as a characterization of the path of the economy around its long run equilibrium (steady states), and involve modelling expectations, learning, and adjustment costs."
                },
                new Subject()
                {
                    Id = new Guid("0250c681-1e01-43a3-9098-a63f45bfeed5"),
                    Name = "Data extraction technologies",
                    Description = "Data extraction involves advanced technologies including database querying, web scraping, etc."
                },
                new Subject()
                {
                    Id = new Guid("e1f903f9-112f-4514-8f16-209640022f2e"),
                    Name = "Information technology in education and business",
                }
            );
        }
    }
}
