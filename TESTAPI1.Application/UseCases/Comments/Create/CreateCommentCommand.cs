using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Application.UseCases.Comments.Create
{
    public class CreateCommentCommand
    {
        public Guid Id { get; set; }
        public Content Content { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid PostId { get; set; }
        public Date CreationDate { get; set; }
    }
}
