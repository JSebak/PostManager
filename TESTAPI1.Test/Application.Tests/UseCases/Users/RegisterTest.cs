using Moq;
using System;
using TESTAPI1.Application.UseCases.Users;
using TESTAPI1.Application.UseCases.Users.Register;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.Enums;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Users
{
    public class RegisterTest
    {
        [Fact]
        public void RegisterUser()
        {
            var UserRepoMock = new Mock<IUserRepository>();
            var registerCase = new RegisterUseCase(UserRepoMock.Object);
            var userId = Guid.Parse("8dec5b93-0fbb-444e-a705-e6dd3707a44a");
            var username = "Usuario";
            var password = "111222";
            var role = UserRole.Writer;
            var creation = DateTime.UtcNow.Date;
            var entity = User.Build(
                userId,
                username,
                password,
                role
                );
            var command = new RegisterUserCommand { UserId = userId, Username =username, Password =password, Role =role};
            UserRepoMock.Setup(p => p.Register(It.Is<User>(entity=>entity.Id == userId 
                                                            && entity.Username == username))).Returns(entity);

            //Act
            var register = registerCase.RegisterUser(command);

            //Assert
            Assert.True(register.Result);
        }
    }
}
