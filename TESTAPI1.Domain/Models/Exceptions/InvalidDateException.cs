using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Domain.Models.Exceptions
{
    public class InvalidDateException : DomainException
    {
        public InvalidDateException(string message) : base(message)
        {
        }
    }
}
