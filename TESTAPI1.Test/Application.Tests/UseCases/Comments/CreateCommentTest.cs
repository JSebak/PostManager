using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Comments;
using TESTAPI1.Application.UseCases.Comments.Create;
using TESTAPI1.Domain.Enities.Comment;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Comments
{
    public class CreateCommentTest
    {
        [Fact]
        public void CreateComment()
        {
            var CommentRepoMock = new Mock<ICommentRepository>();

            var CreateCommentCase = new CreateCommentUseCase(CommentRepoMock.Object);

            var comment = Comment.Build("Content", Guid.Parse("0E6399B2-7CF4-4869-822E-AAD2E0F9A497"), Guid.Parse("0E6399B2-7CF4-4869-822E-AAD2E0F9A497"), Guid.Parse("6ae907d7-2bba-4d96-96f8-d60b9468ce42"), DateTime.UtcNow.Date);

            var command = new CreateCommentCommand { Id = comment.Id, AuthorId = comment.AuthorId, PostId = comment.PostId, Content = comment.Content, CreationDate = comment.CreationDate };
            CommentRepoMock.Setup(c => c.Add(It.Is<Comment>(entity => entity.Id == comment.Id))).Returns(comment);

            //Act
            var created = CreateCommentCase.Create(command);

            //Assert
            Assert.Equal(comment.Id, created.Id);
        }
    }
}
