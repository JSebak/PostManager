using TESTAPI1.Application.Models;

namespace TESTAPI1.Application.UseCases.Posts.GetPosts
{
    public interface IGetPostsUseCase
    {
        public IEnumerable<PostModel> GetPosts();
    }
}
