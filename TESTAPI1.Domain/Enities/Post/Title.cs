using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Exceptions;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Enities.Post
{
    public class Title:ValueObject
    {
        private string value { get; set; }
        public Title(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new EmptyStringException("The Title can't be Empty");
            }
            if (title.Length > 30) throw new InvalidLengthException("Title exceeds the allowed lenght");

            value = title;
        }
        public static implicit operator Title(string value)
        {
            return new Title(value);
        }
        public static implicit operator string(Title title)
        {
            return title.value;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }
}
