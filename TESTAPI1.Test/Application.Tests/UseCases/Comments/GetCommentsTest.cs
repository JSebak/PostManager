using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Comments.Get;
using TESTAPI1.Domain.Enities.Comment;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Comments
{
    public class GetCommentsTest
    {
        [Fact]
        public void GetComments()
        {
            var CommentRepoMock = new Mock<ICommentRepository>();

            var GetCommentsCase = new GetCommentsUseCase(CommentRepoMock.Object);
            var comments = new List<Comment>();
            comments.Add(Comment.Build(
                "LOLz",
                null,
                Guid.Parse("B19F53E3-ACFD-4943-882E-26227DC489A4"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-05-02")
                ));
            comments.Add(Comment.Build(
                "Hello world",
                Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C"),
                Guid.Parse("E07DC6E4-A8C4-4BF4-ACC5-4887C61D7A9E"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-04-22")
                ));
            var postId = Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A");
            CommentRepoMock.Setup(c => c.GetByPost(postId)).Returns(comments);

            //Act
            var postComments = GetCommentsCase.Get(postId); 
            

            //Assert
            Assert.Equal(2, postComments.ToList().Count);
        }
    }
}
