using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.UseCases.Comments.Delete;

namespace TEST_API1.Controllers.Comment
{
    [ApiController]
    [Route("api/comment/[controller]")]
    public class Delete : ControllerBase
    {
        private readonly IDeleteCommentUseCase _deleteUseCase;
        public Delete([NotNull]IDeleteCommentUseCase deleteUseCase)
        {
            _deleteUseCase = deleteUseCase;
        }
        [HttpDelete]
        public IActionResult Execute(Guid comment)
        {
            var succes = _deleteUseCase.Delete(comment);
            if (succes)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
