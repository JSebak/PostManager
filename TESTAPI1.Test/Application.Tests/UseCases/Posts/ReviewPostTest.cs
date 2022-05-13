using Moq;
using System;
using TESTAPI1.Application.UseCases.Posts;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Models.Posts;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class ReviewPostTest
    {
        [Fact]
        public void ReviewPost()
        {
            var PostRepoMock = new Mock<IPostRepository>();

            var reviewPostCase = new ReviewPostUseCase(PostRepoMock.Object);

            var postId = Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A");

            var command = new ReviewPostCommand { Id = postId, Status = true, ApprovalDate = DateTime.UtcNow.Date };

            PostRepoMock.Setup(p => p.GetById(postId)).Returns(Post.Build(
                "The First post Evah",
                "Lorem Ipsum...",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-04-22").Date,
                null,
                false
                ));
            PostRepoMock.Setup(p=>p.Review(command)).Returns(true);

            //Act
            var reviewed = reviewPostCase.Review(command);
            
            //Assert
            Assert.True(reviewed);
        }
    }
}
