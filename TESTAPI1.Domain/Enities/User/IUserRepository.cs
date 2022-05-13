using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Domain.Enities.User
{
    public interface IUserRepository
    {
        public User GetUser(Guid id);

        public IEnumerable<User> GetAll();

        public User GetByUsername(string username);

        public bool UpdateUser(User user);

        public User Register (User user);
    }
}
