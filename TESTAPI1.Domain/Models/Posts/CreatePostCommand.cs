using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Models.Posts
{
    public class CreatePostCommand
    {
        public Guid PostId { get; set; }
        public Date CreationDate { get; set; }
        public Title Title { get; set; }
        public Content Content { get; set; }
        public Guid AuthorId { get; set; }
        public bool? Status { get; set; }
    }
}
