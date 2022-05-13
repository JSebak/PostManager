using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.UseCases.Users.Register
{
    public interface IRegisterUseCase
    {
        public Task<bool> RegisterUser(RegisterUserCommand command);
    }
}
