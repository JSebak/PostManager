using Microsoft.AspNetCore.Mvc;
using TESTAPI1.Application.UseCases.Posts.GetPosts;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class GetPosts : ControllerBase
    {
        private IGetPostsUseCase _getPosts;
        public GetPosts(IGetPostsUseCase getPosts)
        {
            _getPosts = getPosts;
        }
        [HttpGet]
        public IActionResult Execute()
        {
            var posts = _getPosts.GetPosts();
            return Ok(posts);
        }
    }
}
