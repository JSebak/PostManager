using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.GetPending;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class GetPendingPostsTest
    {
        [Fact]
        public void GetPendingPosts()
        {
            var PostRepoMock = new Mock<IPostRepository>();
            var UserRepoMock = new Mock<IUserRepository>();

            var GetPendingCase = new GetPendingPostsUseCase(PostRepoMock.Object, UserRepoMock.Object);
            var entities = new List<Post>();
            var userId = Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C");
            var user = User.Build(userId, "User1", "password", TESTAPI1.Domain.Enums.UserRole.Editor);
            entities.Add(Post.Build(
                "The First post Evah",
                "Lorem Ipsum...",
                userId,
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-04-22").Date,
                null,
                null
                ));
            entities.Add(Post.Build(
                "This is the second post",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                userId,
                Guid.Parse("65561578-0C26-44C0-9466-41E068CFAD0D"),
                DateTime.Parse("2022-04-29").Date,
                DateTime.Parse("2022-05-03").Date,
                true
                ));
            UserRepoMock.Setup(p => p.GetUser(userId)).Returns(user);
            PostRepoMock.Setup(p => p.GetAll()).Returns(entities);

            //Act
            var pending = GetPendingCase.GetPendingPosts(userId);

            Assert.Equal(1,pending.ToList().Count);
        }
    }
}
