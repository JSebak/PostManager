using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.UseCases.Comments.Delete;
using TESTAPI1.Domain.Enities.Comment;

namespace TESTAPI1.Application.UseCases.Comments
{
    public class DeleteCommentUseCase:IDeleteCommentUseCase
    {
        private ICommentRepository _commentRepository;
        public DeleteCommentUseCase([NotNull]ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public bool Delete(Guid commentId)
        {
            var comment = _commentRepository.Get(commentId);
            if (comment == null )
            {
                throw new UnexistingObjectException($"There's no comment with Id: {commentId}");
            }
            return _commentRepository.Delete(comment);
        }
    }
}
