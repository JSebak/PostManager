using Microsoft.AspNetCore.Mvc;
using System.Net;
using TEST_API1.Middleware.Models.Response;
using TEST_API1.Models.Post;
using TESTAPI1.Application.UseCases.Posts.Update;
using TESTAPI1.Domain.Models.Posts;

namespace TEST_API1.Controllers.Posts
{
    [ApiController]
    [Route("api/post/[controller]")]
    public class Update : ControllerBase
    {
        private IUpdatePostUseCase _updatePostUseCase;
        public Update(IUpdatePostUseCase updatePostUseCase)
        {
            _updatePostUseCase = updatePostUseCase;
        }
        [HttpPut]
        public ResponseModel<bool> Execute([FromBody]UpdatePostModel post)
        {
            var command = new UpdatePostCommand { Id = Guid.Parse(post.Id), Title = post.Title, Content = post.Content};
            var response = new ResponseModel<bool>();
            var result = _updatePostUseCase.Update(command);
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Result = result;
            return response;
        }
    }
}
