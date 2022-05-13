using Moq;
using System;
using TESTAPI1.Application.UseCases.Users;
using TESTAPI1.Application.UseCases.Users.Login;
using TESTAPI1.Domain.Enities.User;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Users
{
    public class LoginTest
    {

        [Fact]
        public void LoginUser()
        {
            //Arrange
            var UserRepoMock = new Mock<IUserRepository>();
            var loginCase = new LoginUseCase(UserRepoMock.Object);
            var username = "User1";
            var password = "password";
            var entity = User.Build(
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"), 
                username, 
                password, 
                TESTAPI1.Domain.Enums.UserRole.Editor
                );
            UserRepoMock.Setup(p => p.GetByUsername(username))
                .Returns(entity);
            var command = new LoginUserCommand {  Username = entity.Username, Password = entity.Password };
            
            //Act
            var login = loginCase.LoginUser(command);
           
            //Assert
            Assert.Equal(entity.Id,login.Result.Id);
            }
           
        }


    }
