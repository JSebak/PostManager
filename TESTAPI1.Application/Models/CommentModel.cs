using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPI1.Application.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid? AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
