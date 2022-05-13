namespace TESTAPI1.Application.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? ApprovalDate { get; set; }
        public bool? Status { get; set; }
    }
}
