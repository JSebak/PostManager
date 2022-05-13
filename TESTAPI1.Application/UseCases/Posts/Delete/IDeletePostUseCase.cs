using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Application.UseCases.Posts.Delete
{
    public interface IDeletePostUseCase
    {
        public bool Delete(Guid id);
    }
}
