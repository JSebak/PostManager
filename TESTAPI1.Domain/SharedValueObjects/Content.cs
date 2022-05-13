using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Exceptions;

namespace TESTAPI1.Domain.SharedValueObjects
{
    public sealed class Content: IComparable<Content>
    {
        private string value { get; set; }
        public Content(string newcontent)
        {
            if (string.IsNullOrEmpty(newcontent)) 
            { 
                throw new EmptyStringException("The content cannot be empty");
            }
            if (newcontent.Length > 150) 
            { 
                throw new InvalidLengthException("Exceeded maximum length"); 
            }
            value = newcontent;
        }
        public static implicit operator Content(string value)
        {
            return new Content(value);
        }
        public static implicit operator string(Content content)
        {
            return content.value;
        }

        public int CompareTo(Content? content)
        {
            return content == null ? -1 : content.value.CompareTo(value);
        }
    }
}


