using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Enities.Post
{
    public class Post
    {
        private Post()
        {
        }
        private Post(string title, string content, Guid authorId,Guid postId,DateTime creationDate, DateTime? approvalDate = null, bool? status = null)
        {
            Title = title;
            Content =content;
            Status = status;
            CreationDate = creationDate;
            ApprovalDate = approvalDate;
            AuthorId = authorId;
            Id = postId;
        }
        public static Post Build(Title title, Content content, Guid authorId, Guid postId,DateTime creationDate,DateTime? approvalDate = null, bool? status = null)
        {
            var user = new Post(title, content, authorId, postId,creationDate,approvalDate,status);
            return user;
        }

        public Guid Id { get; }
        public Date CreationDate { get;  }
        public NullableDate? ApprovalDate { get; private set; }

        public Title Title { get; private set; }
        public Content Content { get; private set; }

        public Guid AuthorId { get; private set; }

        public bool? Status { get; private set; }

        public void UpdatePost(string newTitle=null, string newContent=null)
        {
            if(newTitle!=null)Title = new Title(newTitle);
            if(newContent!=null)Content = new Content(newContent);
        }
        public void ChangeStatus(bool? approved, DateTime? date)
        {
            Status = approved;
            if (approved != null && approved!= false)
            {
                ApprovalDate = null;
            }
            else
            {
                ApprovalDate = date;
            }
        }
    }
}
