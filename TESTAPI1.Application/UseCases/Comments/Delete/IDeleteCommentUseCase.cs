using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Application.UseCases.Comments.Delete
{
    public interface IDeleteCommentUseCase
    {
        public bool Delete(Guid commentId);
    }
}
