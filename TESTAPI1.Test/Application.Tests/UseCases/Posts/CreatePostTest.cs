using Moq;
using System;
using TESTAPI1.Application.UseCases.Posts;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.Models.Posts;
using Xunit;

namespace TESTAPI1.Test.Application.Tests.UseCases.Posts
{
    public class CreatePostTest
    {
        [Fact]
        public void CreatePost()
        {
            var PostRepoMock = new Mock<IPostRepository>();
            var UserRepoMock = new Mock<IUserRepository>();

            var createPostCase = new CreatePostUseCase(PostRepoMock.Object, UserRepoMock.Object);
            var id = Guid.Parse("6ae907d7-2bba-4d96-96f8-d60b9468ce42");
            var authorId = Guid.Parse("3EA53E45-7469-4092-AF4E-0CAA6DF0361C");
            var title = "Test";
            var content = "Test text";
            var created = DateTime.UtcNow.Date;
            var entity = Post.Build(
                title,
                content,
                authorId,
                id,
                created
                );

            var command = new CreatePostCommand {
                PostId = id,
                AuthorId = authorId,
                Title = title,
                Content = content,
                CreationDate = created,
                Status = false
            };
            UserRepoMock.Setup(p => p.GetUser( authorId)).Returns(User.Build(authorId, "User1", "password", TESTAPI1.Domain.Enums.UserRole.Writer));
            PostRepoMock.Setup(p => p.Create(It.Is<Post>(entity=> entity.Id == id))).Returns(entity);

            //Act
            var createdPost = createPostCase.CreatePost(command);

            //Assert
            Assert.True(createdPost);
        }
    }
}
