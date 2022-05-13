using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.UseCases.Posts.Delete;
using TESTAPI1.Domain.Enities.Post;

namespace TESTAPI1.Application.UseCases.Posts
{
    public class DeletePostUseCase: IDeletePostUseCase
    {
        private readonly IPostRepository _postRepository;

        public DeletePostUseCase([NotNull]IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public bool Delete(Guid postId)
        {
            var exists = _postRepository.GetById(postId);
            if(exists == null) return false;
            return _postRepository.Delete(postId);
        }
    }
}
