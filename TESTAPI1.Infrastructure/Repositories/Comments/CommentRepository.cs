using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.Models.Comments;

namespace TESTAPI1.Infrastructure.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PostsContext _postContext;
        public CommentRepository([NotNull]PostsContext postsContext)
        {
            _postContext = postsContext;
        }
        public Comment Add(Comment comment)
        {
            var exists = Get(comment.Id);
            if (exists != null)
            {
                throw new Exception();
            }
            var newComment = _postContext.Comments.Add(comment);
            _postContext.SaveChanges();
            return newComment.Entity;
        }

        public bool Delete(Comment comment)
        {
            var exist = Get(comment.Id);
            if (exist == null)
            {
                throw new Exception();
            }
            _postContext.Comments.Remove(comment);
            return _postContext.SaveChanges() == 0 ? false : true;
            
        }

        public Comment Get(Guid commentId)
        {
            var comment = _postContext.Comments.FirstOrDefault(c => c.Id == commentId);
            return comment;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _postContext.Comments.ToList();
        }

        public IEnumerable<Comment> GetByPost(Guid postId)
        {
            return _postContext.Comments.Where(c => c.PostId == postId);
        }

        public bool Update(EditCommentCommand comment)
        {
            var existingComment = Get(comment.Id);
            if (existingComment == null)
            {
                throw new Exception();
            }
            _postContext.Entry(existingComment).CurrentValues.SetValues(comment);
            return _postContext.SaveChanges() == 0 ? false : true;
        }
    }
}
