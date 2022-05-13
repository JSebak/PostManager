using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.Models;
using TESTAPI1.Application.UseCases.Comments.Create;
using TESTAPI1.Domain.Enities.Comment;

namespace TESTAPI1.Application.UseCases.Comments
{
    public class CreateCommentUseCase: ICreateCommentUseCase
    {
        private ICommentRepository _commentRepository;
        public CreateCommentUseCase([NotNull]ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment Create(CreateCommentCommand comment)
        {
            var exists = _commentRepository.Get(comment.Id);
            if(exists != null)
            {
                throw new ExistingObjectException($"There's already a comment with this Id: {comment.Id}");
            }
            var created = Comment.Build(comment.Content, comment.AuthorId == null ? null : comment.AuthorId, comment.Id, comment.PostId, comment.CreationDate);
            var success = _commentRepository.Add(created);
            return success;
        }
    }
}
