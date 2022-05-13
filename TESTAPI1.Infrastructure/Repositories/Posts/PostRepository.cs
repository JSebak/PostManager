using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Infrastructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly PostsContext _postsContext;
        public PostRepository(PostsContext postsContext)
        {
            _postsContext = postsContext;

        }
        public Post Create(Post post)
        {
            var exists = GetById(post.Id);
            if(exists != null)
            {
                throw new Exception();
            }
            var created = _postsContext.Posts.Add(post);
            _postsContext.SaveChanges();
            return created.Entity;
        }

        public bool Delete(Guid postId)
        {
            var post = GetById(postId);
            if(post == null)
            {
                throw new Exception();
            }
            _postsContext.Posts.Remove(post);
            return _postsContext.SaveChanges() == 0 ? false : true;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postsContext.Posts.ToList();
        }

        public IEnumerable<Post> GetAllByUser(Guid id)
        {
            return _postsContext.Posts.Where(p=>p.AuthorId == id).ToList();
        }

        public Post GetById(Guid id)
        {
            var post = _postsContext.Posts.FirstOrDefault(p=>p.Id == id);
            return post;
        }

        public bool Review(ReviewPostCommand post)
        {
            var existingPost = GetById(post.Id);
            if(existingPost == null)
            {
                throw new Exception();
            }
            _postsContext.Entry(existingPost).CurrentValues.SetValues(post);
            return _postsContext.SaveChanges() == 0 ? false: true;
        }

        public bool Update(UpdatePostCommand post)
        {
            var existingPost = GetById(post.Id);
            if(existingPost == null)
            {
                throw new Exception();
            }
            _postsContext.Entry(existingPost).CurrentValues.SetValues(post);
            return _postsContext.SaveChanges() == 0 ? false : true;
        }
    }
}
