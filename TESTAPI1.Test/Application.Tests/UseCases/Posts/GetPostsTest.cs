using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.GetPosts;
using TESTAPI1.Domain.Enities.Post;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class GetPostsTest
    {
        [Fact]
        public void GetPosts()
        {
            var PostRepoMock = new Mock<IPostRepository>();

            var GetPostsCase = new GetPostsUseCase(PostRepoMock.Object);

            var entities = new List<Post>();

            entities.Add(Post.Build(
                "The First post Evah",
                "Lorem Ipsum...",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-04-22").Date,
                null,
                false
                ));
            entities.Add(Post.Build(
                "This is the second post",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                Guid.Parse("65561578-0C26-44C0-9466-41E068CFAD0D"),
                DateTime.Parse("2022-04-29").Date,
                DateTime.Parse("2022-05-03").Date,
                true
                ));

            PostRepoMock.Setup(p => p.GetAll()).Returns(entities);

            //Act
            var posts = GetPostsCase.GetPosts();

            //Assert
            Assert.Equal(1, posts.ToList().Count);

        }
    }
}
