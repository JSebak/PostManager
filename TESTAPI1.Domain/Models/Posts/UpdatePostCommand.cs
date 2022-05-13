using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Models.Posts
{
    public class UpdatePostCommand
    {
        public Guid Id { get; set; }
        public Title Title { get; set; }
        public Content Content { get; set; }
    }
}
