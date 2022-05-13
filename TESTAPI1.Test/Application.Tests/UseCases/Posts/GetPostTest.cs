using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.Get;
using TESTAPI1.Domain.Enities.Post;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class GetPostTest
    {
        [Fact]
        public void GetPost()
        {
            var PostRepoMock = new Mock<IPostRepository>();

            var GetPostCase = new GetUseCase(PostRepoMock.Object);
            var postId = Guid.Parse("65561578-0C26-44C0-9466-41E068CFAD0D");
            var entity = Post.Build(
                "This is the second post",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                postId,
                DateTime.Parse("2022-04-29"),
                DateTime.Parse("2022-05-03"),
                true
                );
            PostRepoMock.Setup(p => p.GetById(postId)).Returns(entity);

            //Act
            var post = GetPostCase.Get(postId);

            //Assert 
            Assert.Equal("This is the second post", post.Title);
        }
    }
}
