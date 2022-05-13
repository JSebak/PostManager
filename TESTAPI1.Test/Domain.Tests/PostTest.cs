using System;
using TESTAPI1.Domain.Enities.Post;
using Xunit;

namespace TESTAPI1.Test.Domain.Tests
{
    public class PostTest
    {
        [Fact]
        public void PostCreation()
        {
            var userId = Guid.NewGuid();
            var title = "Post1";
            var content = "This is a test post";
            var postId = Guid.NewGuid();
            var creationDate = new DateTime(2022, 04, 27);
            var post = Post.Build(title,content, userId, postId,creationDate);
            var newContent = "Post update content";
            var newTitle = "Post1 updated";
            post.UpdatePost();
            Assert.Equal(title, post.Title);

            post.UpdatePost(newTitle);
            Assert.Equal(newTitle, post.Title);

            post.UpdatePost(null,newContent);
            Assert.Equal(newContent, post.Content);


        }
    }
}
