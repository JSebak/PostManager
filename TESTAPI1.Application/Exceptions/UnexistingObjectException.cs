using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models;

namespace TESTAPI1.Application.Exceptions
{
    public class UnexistingObjectException:DomainException
    {
        public UnexistingObjectException(string message) : base(message)
        {

        }
    }
}
