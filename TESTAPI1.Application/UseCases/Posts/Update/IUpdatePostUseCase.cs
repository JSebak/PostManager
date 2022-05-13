using TESTAPI1.Domain.Models.Posts;

namespace TESTAPI1.Application.UseCases.Posts.Update
{
    public interface IUpdatePostUseCase
    {
        public bool Update(UpdatePostCommand command);
    }
}
