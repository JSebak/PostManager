using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TEST_API1.Models.Comment;
using TESTAPI1.Application.UseCases.Comments.Create;

namespace TEST_API1.Controllers.Comment
{
    [ApiController]
    [Route("api/comment/[controller]")]
    public class Create : ControllerBase
    {

        private readonly ICreateCommentUseCase _createUseCase;
        public Create([NotNull] ICreateCommentUseCase createUseCase)
        {
            _createUseCase = createUseCase;
        }
        [HttpPost]
        public IActionResult Execute([FromBody]CommentModel comment)
        {
            var command = new CreateCommentCommand { AuthorId = comment.AuthorId == null ? null : Guid.Parse(comment.AuthorId), Id = Guid.Parse(comment.Id), Content = comment.Content, PostId = Guid.Parse(comment.PostId), CreationDate = DateTime.Parse(comment.CreationDate).Date };
            var succes = _createUseCase.Create(command);
            
            return Ok(succes);
        }
    }
}
