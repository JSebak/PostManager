using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Application.Exceptions;
using TESTAPI1.Application.Models;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;

namespace TESTAPI1.Application.UseCases.Posts.GetByUser
{
    public class GetByUserUseCase: IGetByUserUseCase
    {
        private IPostRepository _postRepository;
        private IUserRepository _userRepository;
        public GetByUserUseCase(IPostRepository postRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }
        public IEnumerable<PostModel> GetUserPosts(Guid userId)
        {
            var writer = _userRepository.GetUser(userId).Role == Domain.Enums.UserRole.Writer;
            if (!writer)
            {
                throw new UnauthorizedException("Not Authorized");
            }
            var query = _postRepository.GetAll().Where(post => post.AuthorId == userId).Select(p =>
            {
                var model = new PostModel { Id = p.Id, AuthorId = p.AuthorId, Title = p.Title, Content = p.Content, CreationDate = p.CreationDate, Status = p.Status, ApprovalDate = p.ApprovalDate };
                return model;
            }).ToList();
            return query;
        }
    }
}
