using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Application.UseCases.Posts.Update
{
    public class UpdatePostUseCase:IUpdatePostUseCase
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostUseCase([NotNull]IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public bool Update(UpdatePostCommand post)
        {
            var result = _postRepository.GetById(post.Id) ?? null;
            if (result == null) throw new UnexistingObjectException($"There's no post with the Id: {post.Id}");
            try
            {
                _postRepository.Update(post);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
