using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Domain.Enities.Post
{
    public interface IPostRepository
    {
        public Post GetById(Guid id);

        public IEnumerable<Post> GetAllByUser(Guid username);

        public IEnumerable<Post> GetAll();

        public bool Update(UpdatePostCommand post);

        public bool Review(ReviewPostCommand post);

        public Post Create(Post post);

        public bool Delete (Guid postId);
    }
}
