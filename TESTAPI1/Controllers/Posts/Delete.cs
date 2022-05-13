using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.UseCases.Posts.Delete;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class Delete : ControllerBase
    {
        private readonly IDeletePostUseCase _deleteUseCase;
        public Delete([NotNull]IDeletePostUseCase deleteUseCase)
        {
            _deleteUseCase = deleteUseCase;
        }

        [HttpDelete]
        public IActionResult Execute(Guid post)
        {
            var succes = _deleteUseCase.Delete(post);
            if (succes)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
