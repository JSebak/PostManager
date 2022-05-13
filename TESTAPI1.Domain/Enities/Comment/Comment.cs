using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Enities.Comment
{
    public class Comment
    {
        private Comment(string content, Guid? authorId, Guid commentId,Guid postId,DateTime creationDate)
        {
            Content = content;
            Id = commentId;
            PostId = postId;
            AuthorId= authorId;
            CreationDate = creationDate;
        }
        private Comment()
        {

        }

        public static Comment Build(Content content, Guid? authorId, Guid commentId, Guid postId, DateTime creationDate)
        {
            return new Comment(content, authorId, commentId, postId,creationDate);
        }
        public Guid Id { get ; }

        public Content Content {
            get; private set; 
        }

        public Guid? AuthorId { get; private set; }
        public Guid PostId { get; private set; }

        public Date CreationDate { get; private set; }

        public void EditComment(string newcontent)
        {
            Content = newcontent;
        }

    }

}
