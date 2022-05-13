using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Domain.Models
{
    public class DomainException:Exception
    {
        public DomainException(string message):base(message){}

    }
}
