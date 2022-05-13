using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Comments;

namespace TESTAPI1.Domain.Enities.Comment
{
    public interface ICommentRepository
    {
        public Comment Add(Comment comment);
        public IEnumerable<Comment> GetAll();
        public Comment Get(Guid commentId);
        public IEnumerable<Comment> GetByPost(Guid postId);
        public bool Delete(Comment comment);
        public bool Update(EditCommentCommand comment);
    }
}
