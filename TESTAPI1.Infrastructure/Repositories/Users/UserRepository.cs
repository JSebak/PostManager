using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly PostsContext _postsContext;
        public UserRepository(PostsContext postsContext)
        {
            _postsContext = postsContext ?? throw new ArgumentNullException(nameof(postsContext));
        }
        public IEnumerable<User> GetAll()
        {
            var users = _postsContext.Users.ToList();
            return users;
        }

        public User GetByUsername(string username)
        {
             var user = _postsContext.Users.Where(u => u.Username == username).FirstOrDefault();
            return user;

        }

        public User GetUser(Guid id)
        {
            var user = _postsContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User Register(User user)
        {
            var created = _postsContext.Users.Add(user);
            _postsContext.SaveChanges();
            return created.Entity;
        }

        public bool UpdateUser(User user)
        {
            var existingUser = GetUser(user.Id);
            if(existingUser == null)
            {
                throw new Exception();
            }
            _postsContext.Entry(existingUser).CurrentValues.SetValues(user);
            return _postsContext.SaveChanges() == 0 ? false : true;
        }
    }
}
