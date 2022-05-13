using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Models.Posts
{
    public class ReviewPostCommand
    {
        public Guid Id { get; set; }
        public bool? Status { get; set; }
        public NullableDate? ApprovalDate { get; set; }
    }
}
