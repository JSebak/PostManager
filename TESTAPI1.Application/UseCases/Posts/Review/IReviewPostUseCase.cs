using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Application.UseCases.Posts.Review
{
    public interface IReviewPostUseCase
    {
        public bool Review(ReviewPostCommand command);
    }
}
