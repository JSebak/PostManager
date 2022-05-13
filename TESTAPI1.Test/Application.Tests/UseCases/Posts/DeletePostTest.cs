using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts;
using TESTAPI1.Domain.Enities.Post;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class DeletePostTest
    {
        [Fact]
        public void DeletePost()
        {
            var PostRepoMock = new Mock<IPostRepository>();

            var DeletePostCase = new DeletePostUseCase(PostRepoMock.Object);

            var postId = Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A");

            PostRepoMock.Setup(x => x.GetById(postId)).Returns(Post.Build(
                "The First post Evah",
                "Lorem Ipsum...",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-04-22").Date,
                null,
                false
                ));
            PostRepoMock.Setup(p=>p.Delete(postId)).Returns(true);

            //Act
            var deleted = DeletePostCase.Delete(postId);

            //Assert
            Assert.True(deleted);
        }
    }
}
