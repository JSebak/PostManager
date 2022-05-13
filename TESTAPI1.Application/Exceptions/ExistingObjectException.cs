using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models;

namespace TESTAPI1.Application.Exceptions
{
    public class ExistingObjectException:DomainException
    {
        public ExistingObjectException(string message): base(message)
        {

        }
    }
}
