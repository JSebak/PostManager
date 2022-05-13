
using System;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.Enums;
using Xunit;

namespace TESTAPI1.Test.Domain.Tests
{
    public class UserTest
    {
    [Fact]
        public void UserCreation()
        {
            var username = "Matt";
            var userId = Guid.NewGuid();
            var password = "password";
            var role = UserRole.Editor;
            var creationDate = new DateTime(2022, 04, 27);
            var user = User.Build(userId, username, password, role);
            Assert.Equal(username, user.Username);
        }
    }
}
