using TESTAPI1.Application.Exceptions;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.Models.Comments;

namespace TESTAPI1.Application.UseCases.Comments.Edit
{
    public class EditCommentUseCase:IEditCommentUseCase
    {
        private ICommentRepository _commentRepository;
        public EditCommentUseCase(ICommentRepository commentRepository)
        {
            _commentRepository =commentRepository;
        }
        public bool Edit(EditCommentCommand command)
        {
            var comment = _commentRepository.Get(command.Id);
            if (comment == null)
            {
                throw new UnexistingObjectException($"The comment with the Id: {command.Id} doesn't exists");
            }
            comment.EditComment(command.Content);
            return _commentRepository.Update(command);
        }

    }
}
