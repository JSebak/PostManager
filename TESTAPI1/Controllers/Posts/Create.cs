using Microsoft.AspNetCore.Mvc;
using TEST_API1.Models;
using TEST_API1.Models.Post;
using TESTAPI1.Application.Models;
using TESTAPI1.Application.UseCases.Posts.Create;
using TESTAPI1.Domain.Models.Posts;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class Create : ControllerBase
    {
        private readonly ICreatePostUseCase _createUseCase;

        public Create( ICreatePostUseCase saveUseCase)
        {
            _createUseCase = saveUseCase;
        }

        [HttpPost]
        public IActionResult Execute([FromBody] CreatePostModel post)
        {
            var command = new CreatePostCommand
            {
                Content = post.Content,
                Title = post.Title,
                AuthorId = Guid.Parse(post.AuthorId),
                PostId = Guid.Parse(post.Id),
                CreationDate = DateTime.Parse(post.CreationDate),
                Status = post.Status == null ? null : Boolean.Parse(post.Status)
            };
            return Ok(_createUseCase.CreatePost(command));
        }

    }
}