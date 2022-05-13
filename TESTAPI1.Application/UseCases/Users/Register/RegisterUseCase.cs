using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.UseCases.Users.Register;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.UseCases.Users
{
    public class RegisterUseCase: IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        public RegisterUseCase([NotNull]IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> RegisterUser(RegisterUserCommand command)
        {
            var userId = command.UserId;
            var registeredUsers = _userRepository.GetUser(userId);
            if (registeredUsers != null)
            {
                throw new ExistingObjectException("Username already registered.");
            }
            var user = User.Build(userId, command.Username, command.Password, command.Role);
            var registered = _userRepository.Register(user);
            return new Task<bool>(() => registered != null ? true : false);
        }

    }
}
