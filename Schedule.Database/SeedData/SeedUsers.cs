using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Database.SeedData
{
    internal class SeedUsers : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            #region Teachers

                new User()
                {
                    Id = new Guid("2a8fd411-d328-42a7-adca-f8d58f14c84c"),
                    FirstName = "Serhii",
                    LastName = "Yaroshko",
                    Email = "serhii.yaroshko@gmail.com",
                    Phone = "0683006031",
                    Role = Core.Enums.Role.Teacher,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher123"),
                    ActivatedDate = DateTime.UtcNow,
                },

                new User()
                {
                    Id = new Guid("db67f91d-5e59-48df-9b4a-d786480e09c6"),
                    FirstName = "Lesya",
                    LastName = "Klakovych",
                    Email = "lesya.klakovych@gmail.com",
                    Phone = "0683006033",
                    Role = Core.Enums.Role.Teacher,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher123"),
                    ActivatedDate = DateTime.UtcNow,
                },

                new User()
                {
                    Id = new Guid("12e05dcf-6b56-4105-bbb6-390752fa6873"),
                    FirstName = "Mykola",
                    LastName = "Prytula",
                    Email = "mykola.prytula@gmail.com",
                    Phone = "0683006036",
                    Role = Core.Enums.Role.Teacher,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher123"),
                    ActivatedDate = DateTime.UtcNow,
                },

                 new User()
                 {
                     Id = new Guid("469ac11e-2dca-45cb-ae12-74d6e80b52ab"),
                     FirstName = "Nadia",
                     LastName = "Kolos",
                     Email = "nadia.kolos@gmail.com",
                     Phone = "0683006038",
                     Role = Core.Enums.Role.Teacher,
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("teacher123"),
                     ActivatedDate = DateTime.UtcNow,
                 },

            #endregion

            #region Students

                new User()
                {
                    Id = new Guid("afeca91b-bdcd-4633-a093-d12a8c5fc94e"),
                    FirstName = "Volodymyr",
                    LastName = "Didukh",
                    Email = "ddux05@gmail.com",
                    Phone = "0683006028",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("35944557-7c35-43bd-b85a-2062fea9dae6"),
                    FirstName = "Maria",
                    LastName = "Skab",
                    Email = "mariask@gmail.com",
                    Phone = "0983001023",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("1dc4abce-2d28-458c-9384-cb2fbac8d651"),
                    FirstName = "Julia",
                    LastName = "Kachmar",
                    Email = "juliakc@gmail.com",
                    Phone = "0983001024",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("d773b333-4ef2-4bb6-b5c2-35cae2fe3f54"),
                    FirstName = "Nazar",
                    LastName = "Petrychko",
                    Email = "nazarpe@gmail.com",
                    Phone = "0983001025",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("ceb3c63e-b2d6-40ce-b491-04f8dff69390"),
                    FirstName = "Roman",
                    LastName = "Khudobliak",
                    Email = "romankh@gmail.com",
                    Phone = "0983001026",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("7bec8f02-838b-45cf-ba28-1ea6f2d6f6da"),
                    FirstName = "Andrii",
                    LastName = "Hirniy",
                    Email = "andriihi@gmail.com",
                    Phone = "0983001027",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                new User()
                {
                    Id = new Guid("209dc40c-66cb-424b-8734-7d8374998ca3"),
                    FirstName = "Bohdan",
                    LastName = "Yakimets",
                    Email = "bohdanya@gmail.com",
                    Phone = "0983001028",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                },

                 new User()
                 {
                     Id = new Guid("d9707a0d-3fb9-4382-aebe-33a123e20a9d"),
                     FirstName = "Bohdan",
                     LastName = "Yatsiv",
                     Email = "bohdanyats@gmail.com",
                     Phone = "0983001029",
                     Role = Core.Enums.Role.Student,
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                     ActivatedDate = DateTime.UtcNow,
                     GroupId = new Guid("d96fc6d4-43f5-4191-b82a-f43b762464dd")
                 },

                new User()
                {
                    Id = new Guid("f6a5fa16-9e8c-462a-b69b-7b0e83477d6c"),
                    FirstName = "Kostiantyn",
                    LastName = "Strusovskyi",
                    Email = "gradkep@gmail.com",
                    Phone = "0993810000",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("0b22c341-cdfc-422c-a014-7e22e29d6c8b")
                },

                new User()
                {
                    Id = new Guid("18517924-ec8a-4571-a66b-4b34cfb40775"),
                    FirstName = "Daria",
                    LastName = "Vasilieva",
                    Email = "dariava@gmail.com",
                    Phone = "0993810012",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d80a3de5-29d6-4b7a-97c3-6b46925ec669")
                },

                new User()
                {
                    Id = new Guid("519891c4-430e-49df-8ec4-4e8e521b178a"),
                    FirstName = "Viktoria",
                    LastName = "Buhai",
                    Email = "viktoriabuh@gmail.com",
                    Phone = "0993810014",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("d80a3de5-29d6-4b7a-97c3-6b46925ec669")
                },

                new User()
                {
                    Id = new Guid("7b6aedab-9d23-4759-a04b-185b999289fe"),
                    FirstName = "Yuriy",
                    LastName = "Ben",
                    Email = "yuriyben@gmail.com",
                    Phone = "0993810016",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("6ec87e45-1a07-496b-a2df-7cc1b8d8e1e1")
                },

                new User()
                {
                    Id = new Guid("d4d9c50f-54f1-431a-88ad-21c3edc6ac33"),
                    FirstName = "Mariana",
                    LastName = "Karabin",
                    Email = "marianaka@gmail.com",
                    Phone = "0993810018",
                    Role = Core.Enums.Role.Student,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("qwerty123"),
                    ActivatedDate = DateTime.UtcNow,
                    GroupId = new Guid("6ec87e45-1a07-496b-a2df-7cc1b8d8e1e1")
                }

                #endregion
            );
        }
    }
}
