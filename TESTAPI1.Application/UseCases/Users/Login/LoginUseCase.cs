using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.Interfaces.Users;
using TESTAPI1.Application.Models;
using TESTAPI1.Application.UseCases.Users.Login;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.UseCases.Users
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;

        public LoginUseCase([NotNull]IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> LoginUser(LoginUserCommand command)
        {
            string username = command.Username;
            string password = command.Password;
            if(username == null || password == null)
            {
                throw new IncompleteLoginException("Please enter a valid username and password");
            }
            var user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new UnexistingObjectException($"There's no user registered with the username: {username}");
            }
            if(user.Username != username || user.Password != password)
            {
                throw new InvalidLoginException("Wrong username or password.");
            }
            var loggedUser = new UserModel { Id = user.Id, Username = user.Username, Password = user.Password, Role = user.Role };
            return loggedUser; 
        }

    }
}
