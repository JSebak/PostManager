using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.UseCases.Posts.GetPending;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class GetPending : ControllerBase
    {
        private IGetPendingPostsUseCase _getPending;
        public GetPending([NotNull]IGetPendingPostsUseCase getPending)
        {
            _getPending = getPending;
        }
        [HttpGet("{id}")]
        public IActionResult Execute(string id)
        {
            var user = Guid.Parse(id);
            var posts = _getPending.GetPendingPosts(user);
            return Ok(posts);
        }
    }
}
