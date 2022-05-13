using Microsoft.AspNetCore.Mvc;
using TEST_API1.Models.Comment;
using TESTAPI1.Application.UseCases.Comments.Edit;
using TESTAPI1.Domain.Models.Comments;

namespace TEST_API1.Controllers.Comment
{
    [ApiController]
    [Route("api/comment/[controller]")]
    public class Edit : ControllerBase
    {
        private readonly IEditCommentUseCase _editComment;

        public Edit(IEditCommentUseCase editComment)
        {
            _editComment = editComment;
        }
        [HttpPut]
        public IActionResult Execute([FromBody] EditCommentModel comment)
        {
            var command = new EditCommentCommand { Id = Guid.Parse(comment.Id), Content = comment.Content };
            return Ok(_editComment.Edit(command));
        }
    }
}
