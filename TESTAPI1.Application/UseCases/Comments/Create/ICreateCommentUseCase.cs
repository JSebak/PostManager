using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Enities.Comment;

namespace TESTAPI1.Application.UseCases.Comments.Create
{
    public interface ICreateCommentUseCase
    {
        public Comment Create(CreateCommentCommand command);
    }
}
