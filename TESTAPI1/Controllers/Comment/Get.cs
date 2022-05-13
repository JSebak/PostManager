using Microsoft.AspNetCore.Mvc;
using TESTAPI1.Application.UseCases.Comments.Get;

namespace TEST_API1.Controllers.Comment
{
    [ApiController]
    [Route("api/comment/[controller]")]
    public class Get : ControllerBase
    {
        private IGetCommentsUseCase _getComments;
        public Get(IGetCommentsUseCase getComments)
        {
            _getComments = getComments;
        }
        [HttpGet("{postId}")]
        public IActionResult Execute(Guid postId)
        {
            return Ok(_getComments.Get(postId));
        }
    }
}
