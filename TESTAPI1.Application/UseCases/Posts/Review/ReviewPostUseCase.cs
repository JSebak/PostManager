using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.UseCases.Posts.Review;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Application.UseCases.Posts
{
    public class ReviewPostUseCase: IReviewPostUseCase
    {
        private IPostRepository _postRepository;
        public ReviewPostUseCase([NotNull]IPostRepository postRepository )
        {
            _postRepository = postRepository;
        }

        public bool Review(ReviewPostCommand command)
        {
            var post = _postRepository.GetById(command.Id);
            if( post == null)
            {
                throw new UnexistingObjectException($"There's no post with the Id: {command.Id}");
            }

                post.ChangeStatus(command.Status,command.ApprovalDate ?? null);
                _postRepository.Review(command);
            return true; 
        }
    }
}
