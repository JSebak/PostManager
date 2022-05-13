using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Models.Comments
{
    public class EditCommentCommand
    {
        public Guid Id { get; set; }
        public Content Content { get; set; }
    }
}
