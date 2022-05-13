using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Enums;

namespace TESTAPI1.Application.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get;  set; }
        public string Password { get;  set; }
        public UserRole Role { get; set; }

    }
}
