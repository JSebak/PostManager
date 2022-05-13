using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.Models;

namespace TESTAPI1.Application.UseCases.Posts.GetPending
{
    public interface IGetPendingPostsUseCase
    {
        public IEnumerable<PostModel> GetPendingPosts(Guid user);
    }
}
