using TESTAPI1.Application.Models;
using TESTAPI1.Application.UseCases.Users.Login;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.Interfaces.Users
{
    public interface ILoginUseCase
    {
        public Task<UserModel> LoginUser(LoginUserCommand command);
    }
}
