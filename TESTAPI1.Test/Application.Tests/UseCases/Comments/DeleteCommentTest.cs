using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Comments;
using TESTAPI1.Domain.Enities.Comment;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Comments
{
    public class DeleteCommentTest
    {
        [Fact]
        public void DeleteComment()
        {
            var CommentRepoMock = new Mock<ICommentRepository>();

            var DeleteCommentCase = new DeleteCommentUseCase(CommentRepoMock.Object);

            var commentId = Guid.Parse("B19F53E3-ACFD-4943-882E-26227DC489A4");
            var comment = Comment.Build("LOLz", null, commentId, Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"), DateTime.Parse("2022-05-02"));
            CommentRepoMock.Setup(c => c.Get(commentId)).Returns(comment);
            CommentRepoMock.Setup(c => c.Delete(comment)).Returns(true);

            //Act
            var deleted = DeleteCommentCase.Delete(commentId);

            //Assert
            Assert.True(deleted);
        }
    }
}
