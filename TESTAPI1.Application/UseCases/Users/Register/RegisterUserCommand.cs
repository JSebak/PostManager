using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Domain.Enums;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Application.UseCases.Users.Register
{
    public class RegisterUserCommand
    {
        public Guid UserId { get; set; }
        public Username Username { get; set; }
        public Password Password { get; set; }
        public UserRole Role { get; set; }
    }
}
