using TESTAPI1.Domain.Enums;

namespace TESTAPI1.Domain.Enities.User
{
    public sealed class User
    {
        private User(Guid userId, Username userName, Password password, UserRole role)
        {
            Username = userName;
            Role = role;
            Id = userId;
            Password = password;
        }
        private User()
        {

        }

        public static User Build(Guid id, Username username,Password password, UserRole role)
        {
            var user = new User(id,username, password,role);
            return user;
        }
        public Guid Id { get;  }
        public Username Username { get; private set; }
        public Password Password { get; private set; }
        public UserRole Role { get; }

        public void ChangePassword(Password password)
        {
            Password = password;
        }
        
    }
}
