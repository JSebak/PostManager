using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Post;

namespace TESTAPI1.Application.UseCases.Posts.Get
{
    public class GetUseCase : IGetUseCase
    {
        private IPostRepository _postRepository;
        public GetUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public PostModel Get(Guid postId)
        {
            var post = _postRepository.GetById(postId);
            if(post == null)
            {
                throw new Exception();
            }
            return new PostModel 
            { 
                Id = post.Id,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Content = post.Content,
                CreationDate = post.CreationDate,
                Status = post.Status,
                ApprovalDate = post.ApprovalDate 
            };
        }
    }
}
