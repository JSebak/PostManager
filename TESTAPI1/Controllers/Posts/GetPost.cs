using Microsoft.AspNetCore.Mvc;
using TESTAPI1.Application.UseCases.Posts.Get;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class GetPost : ControllerBase
    {
        private IGetUseCase _getUseCase;
        public GetPost(IGetUseCase getUseCase)
        {
            _getUseCase = getUseCase;

        }
        [HttpGet("{postId}")]
        public IActionResult Execute(Guid postId)
        {
           return Ok(_getUseCase.Get(postId));
        }
    }
}
