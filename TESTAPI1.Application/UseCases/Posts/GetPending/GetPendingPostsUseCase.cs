using System.Diagnostics.CodeAnalysis;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.UseCases.Posts.GetPending
{
    public class GetPendingPostsUseCase : IGetPendingPostsUseCase
    {
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;
        public GetPendingPostsUseCase([NotNull]IPostRepository postRepository, [NotNull]IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public IEnumerable<PostModel> GetPendingPosts(Guid user)
        {
            var editor = _userRepository.GetUser(user).Role == Domain.Enums.UserRole.Editor;
            if (!editor)
            {
                throw new UnauthorizedException("Not Authorized");
            }
            var query = _postRepository.GetAll().Where(post => post.Status == null).Select(p =>
            {
                var model = new PostModel { Id = p.Id, AuthorId = p.AuthorId, Title = p.Title, Content = p.Content, CreationDate = p.CreationDate, Status =p.Status, ApprovalDate = p.ApprovalDate };
                return model;
            }).ToList();
            return query;
        }
    }
}
