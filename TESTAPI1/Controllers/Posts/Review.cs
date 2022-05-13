using Microsoft.AspNetCore.Mvc;
using TEST_API1.Models.Post;
using TESTAPI1.Application.UseCases.Posts.Review;
using TESTAPI1.Domain.Models.Posts;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class Review : ControllerBase
    {
        private IReviewPostUseCase _reviewPostUseCase;
        public Review(IReviewPostUseCase reviewPostUseCase)
        {
            _reviewPostUseCase = reviewPostUseCase;
        }
        [HttpPut]
        public IActionResult Execute([FromBody] ReviewPostModel post)
        {
            var command = new ReviewPostCommand 
            { 
                Id = Guid.Parse(post.Id),
                Status = post.Status != null ? bool.Parse(post.Status) : null ,
                ApprovalDate = post.ApprovalDate == null ? null : DateTime.Parse(post.ApprovalDate).Date 
            };
            return Ok(_reviewPostUseCase.Review(command));
        }
    }
}
