using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Enities.Comment;
using Xunit;

namespace TESTAPI1.Test.Domain.Tests
{
    public class CommentTest
    {
        [Fact]
        public void CommentCreation()
        {
            var userId = Guid.NewGuid();
            var creationDate = new DateTime(2022, 04, 27);
            var commentId = Guid.NewGuid();
            var content = "This is a test comment";
            var postId = Guid.NewGuid();
            var comment = Comment.Build(content,userId,commentId,postId,creationDate);
            var newContent = "Comment update content";
            
            Assert.Equal(content, comment.Content);

            comment.EditComment(newContent);
            Assert.Equal(newContent, comment.Content);

        }
    }
}
