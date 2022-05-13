using Microsoft.AspNetCore.Mvc;
using TESTAPI1.Application.UseCases.Posts.GetByUser;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class GetByUser : ControllerBase
    {
        private IGetByUserUseCase _getByUser;
        public GetByUser(IGetByUserUseCase getByUser)
        {
            _getByUser = getByUser;

        }
        [HttpGet("{userId}")]
        public IActionResult Execute(Guid userId)
        {
            return Ok(_getByUser.GetUserPosts(userId));
        }
    }
}
