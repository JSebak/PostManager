using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Post;

namespace TESTAPI1.Application.UseCases.Posts.GetPosts
{
    public class GetPostsUseCase : IGetPostsUseCase
    {
        private IPostRepository _postRepository;
        public GetPostsUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IEnumerable<PostModel> GetPosts()
        {
           var posts = _postRepository.GetAll().Where(p=> p.Status == true).Select(p =>
           {
               var post = new PostModel { Id = p.Id, AuthorId = p.AuthorId, Title = p.Title, Content = p.Content, CreationDate = p.CreationDate, Status = p.Status, ApprovalDate = p.ApprovalDate };
               return post;
           }).ToList();
            return posts;
        }
    }
}
