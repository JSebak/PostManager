using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Comments;

namespace TESTAPI1.Application.UseCases.Comments.Edit
{
    public interface IEditCommentUseCase
    {
        public bool Edit(EditCommentCommand command);
    }
}
