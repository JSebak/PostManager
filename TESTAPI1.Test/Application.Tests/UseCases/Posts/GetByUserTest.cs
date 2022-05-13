using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.GetByUser;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class GetByUserTest
    {
        [Fact]
        public void GetByUser()
        {
            var PostRepoMock = new Mock<IPostRepository>();
            var UserRepoMock = new Mock<IUserRepository>();

            var GetByUserCase = new GetByUserUseCase(PostRepoMock.Object, UserRepoMock.Object);
            var entities = new List<Post>();
            var userId = Guid.Parse("0e6399b2-7cf4-4869-822e-aad2e0f9a497");
            var user = User.Build(userId, "User2", "123456", TESTAPI1.Domain.Enums.UserRole.Writer);
            entities.Add(Post.Build(
                "Ui post test",
                "The admin should review this new post",
                userId,
                Guid.Parse("31424D16-BE9B-C14A-8949-0467D409247C"),
                DateTime.Parse("2022-05-12").Date,
                DateTime.Parse("2022 - 05 - 13").Date,
                true
                ));
            entities.Add(Post.Build(
                "New Test",
                "123123123123123123123",
                userId,
                Guid.Parse("F19022C6-22F2-04B0-E232-F46C00019976"),
                DateTime.Parse("2022-05-13").Date,
                null,
                null
                ));
            UserRepoMock.Setup(p => p.GetUser(userId)).Returns(user);
            PostRepoMock.Setup(p => p.GetAll()).Returns(entities);

            //Act
            var userPosts = GetByUserCase.GetUserPosts(userId);

            Assert.Equal(2, userPosts.ToList().Count);
        }
    }
}
