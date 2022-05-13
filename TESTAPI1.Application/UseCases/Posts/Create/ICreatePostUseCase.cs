using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Application.UseCases.Posts.Create
{
    public interface ICreatePostUseCase
    {
        public bool CreatePost(CreatePostCommand command);
    }
}
