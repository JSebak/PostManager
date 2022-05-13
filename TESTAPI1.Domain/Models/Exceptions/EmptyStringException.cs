using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Domain.Models.Exceptions
{
    public class EmptyStringException : DomainException
    {
        public EmptyStringException(string message) : base(message)
        {
        }
    }
}
