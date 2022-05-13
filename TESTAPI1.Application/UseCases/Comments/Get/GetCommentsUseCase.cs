using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Comment;

namespace TESTAPI1.Application.UseCases.Comments.Get
{
    public class GetCommentsUseCase : IGetCommentsUseCase
    {
        private ICommentRepository _commentRepository;

        public GetCommentsUseCase(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public IEnumerable<CommentModel> Get(Guid postId)
        {
            var comments = _commentRepository.GetByPost(postId).ToList();
            if(comments == null || comments.Count == 0)
            {
                return null;
            }
            var modelComments = comments.Select(c =>
             {
                 return new CommentModel
                 {
                     Id = c.Id,
                     AuthorId = c.AuthorId,
                     Content = c.Content,
                     PostId = c.PostId,
                     CreationDate = c.CreationDate
                 };
             });
            return modelComments;
        }
    }
}
