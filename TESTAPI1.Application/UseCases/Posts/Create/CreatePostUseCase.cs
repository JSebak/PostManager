using TESTAPI1.Domain.Enities.User;

using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Application.UseCases.Posts.Create;
using TESTAPI1.Domain.Models.Posts;
using TESTAPI1.Application.Exceptions;

namespace TESTAPI1.Application.UseCases.Posts
{
    public class CreatePostUseCase:ICreatePostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CreatePostUseCase([NotNull] IPostRepository postRepository, [NotNull] IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public bool CreatePost(CreatePostCommand command)
        {
            var postExists = _postRepository.GetById(command.PostId);
            
            if (postExists!=null)
            {
                throw new ExistingObjectException($"There's already a post with the Id: {command.PostId}");
            }
            var userExists = _userRepository.GetUser(command.AuthorId);
            if (userExists == null)
            {
                throw new UnexistingObjectException($"There's no user with the Id: {command.AuthorId}");
            }
            var post = Post.Build(command.Title,command.Content,command.AuthorId,command.PostId,command.CreationDate);
            var success = _postRepository.Create(post);
            return success != null ? true : false;
        }
    }
}
