using Microsoft.AspNetCore.Mvc;
using TEST_API1.Models.User;
using TESTAPI1.Application.UseCases.Users.Register;
using TESTAPI1.Domain.Enums;

namespace TEST_API1.Controllers.User
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class Register : ControllerBase
    {
        private readonly IRegisterUseCase _registerUseCase;

        public Register(IRegisterUseCase registerUseCase)
        {

            _registerUseCase = registerUseCase;
        }
        [HttpPost]
        public IActionResult Execute([FromBody] RegisterModel register)
        {
            var registerCommand = new RegisterUserCommand { Username = register.Username, Password = register.Password, Role = (UserRole)int.Parse(register.Role), UserId = Guid.Parse(register.Id)};
            var user = _registerUseCase.RegisterUser(registerCommand).Result;
            return Ok(user);
        }
    }
}
