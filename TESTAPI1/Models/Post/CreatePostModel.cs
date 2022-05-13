namespace TEST_API1.Models.Post
{
    public class CreatePostModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string CreationDate { get; set; }
        public string? ApprovalDate { get; set; }
        public string? Status { get; set; }
    }
}
