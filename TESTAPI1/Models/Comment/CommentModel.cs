namespace TEST_API1.Models.Comment
{
    public class CommentModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string? AuthorId { get; set; }
        public string PostId { get; set; }
        public string CreationDate { get; set; }
    }
}
