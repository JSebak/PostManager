using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Comments.Edit;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.Models.Comments;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Comments
{
    public class EditCommentTest
    {
        [Fact]
        public void EditComment()
        {
            var CommentRepoMock = new Mock<ICommentRepository>();

            var EditCase = new EditCommentUseCase(CommentRepoMock.Object);

            var entity = Comment.Build(
                "LOLz",
                null,
                Guid.Parse("B19F53E3-ACFD-4943-882E-26227DC489A4"),
                Guid.Parse("C3F47802-4362-49C7-BD76-DC1C5E95655A"),
                DateTime.Parse("2022-05-02")
                );
            
            CommentRepoMock.Setup(x => x.Get(entity.Id)).Returns(entity);

            var command = new EditCommentCommand { Id = entity.Id, Content = "ROFL" };
            CommentRepoMock.Setup(c => c.Update(It.Is<EditCommentCommand>(e => e.Id == entity.Id 
                                                                ))).Returns(true);
            //Act
            var edited = EditCase.Edit(command);

            //Assert

            Assert.True(edited);
        }
    }
}
