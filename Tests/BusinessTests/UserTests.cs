using Moq;
using Schedule.Core.Entities.Account;
using Schedule.Database.Repository.Implementations.Base;
using Schedule.Database.Repository.Interfaces;
using Schedule.Database.Repository.Interfaces.Base;
using System;
using System.Threading.Tasks;
using Tests.Mocks;
using Xunit;

namespace Tests.BusinessTests
{
    public class UserTests
    {
        #region Properties

        public SqlRepository<User> UserRepository;
        public IUnitOfWork Context;
        public User CorrectUser;

        #endregion

        #region Constructor

        public UserTests()
        {
            UserRepository = new SqlRepository<User>(new Mock);

            //var unitOfWork = new Mock<IUnitOfWork>();
            //unitOfWork.Setup(x => x.SaveChangesAsync(default));
            //unitOfWork.Setup(x => x.Repository<User>()).Returns(UserRepository);
            //Context = unitOfWork.Object;

            CreateCorrectUser();
        }

        #endregion

        #region Tests

        [Fact]
        public async Task TestExistAsync()
        {
            var doesUserExist = await UserRepository.ExistAsync(i => i.Email == "stepan@selo.com");
            Assert.True(doesUserExist);
        }

        #endregion

        #region Helpers

        private void CreateCorrectUser()
        {
            CorrectUser = new User
            {
                Id = Guid.Parse("11111111111111111111111111111111"),
                Email = "stepan@selo.com",
                Phone = "0500000000",
                FirstName = "Stepan",
                LastName = "Selian",
            };
        }

        #endregion
    };
}