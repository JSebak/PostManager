using Microsoft.AspNetCore.Mvc;
using TEST_API1.Middleware.Models.Response;
using TEST_API1.Models;
using TESTAPI1.Application.Interfaces.Users;
using TESTAPI1.Application.UseCases.Users;
using TESTAPI1.Application.UseCases.Users.Login;

namespace TEST_API1.Controllers
{
    [Route("api/user/[controller]")]
    public class Login : Controller
    {
        private readonly ILoginUseCase _loginUseCase;

        public Login(ILoginUseCase loginUseCase)
        {

            _loginUseCase = loginUseCase;
        }
        [HttpPost]
        public ResponseModel<UserModel> Execute([FromBody] LoginModel login)
        {
            var loginCommand = new LoginUserCommand { Username = login.UserName, Password = login.Password };
            var user = _loginUseCase.LoginUser(loginCommand).Result;
            var response = new ResponseModel<UserModel>();
            if(user != null)
            {
                response.StatusCode = 200;
                response.Result = new UserModel { Id = user.Id.ToString(), Username = user.Username, Password = user.Password, Role = user.Role.ToString()};
            }
            return response;
        }
    }
}
