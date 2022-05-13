using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.Models;

namespace TESTAPI1.Application.UseCases.Posts.Get
{
    public interface IGetUseCase
    {
        public PostModel Get(Guid postId);
    }
}
