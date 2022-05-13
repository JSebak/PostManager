using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.Update;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Models.Posts;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class UpdatePostTest
    {
        [Fact]
        public void UpdatePost()
        {
            var PostRepoMock = new Mock<IPostRepository>();

            var UpdatePostCase = new UpdatePostUseCase(PostRepoMock.Object);
            var postId = Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A");
            var post = Post.Build(
                "The First post Evah",
                "Lorem Ipsum...",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                postId,
                DateTime.Parse("2022-04-22").Date,
                null,
                false
                );
            PostRepoMock.Setup(p=>p.GetById(postId)).Returns(post);
            var command = new UpdatePostCommand { Id = post.Id, Title = "The updated post", Content = "Yay!" };
            PostRepoMock.Setup(p => p.Update(command)).Returns(true);

            //Act
            var updated = UpdatePostCase.Update(command);

            //Assert 
            Assert.True(updated);
        }
    }
}
