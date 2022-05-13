using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.Enums;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Application.UseCases.Users.Login
{
    public class LoginUserCommand
    {
        public Username Username { get; set; }
        public Password Password { get; set; }

    }
}
