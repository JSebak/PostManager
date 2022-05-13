using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Exceptions;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Enities.User
{
    public sealed class Password:ValueObject
    {
        private const short ValueMinLength = 6;
        private const short ValueMaxLength = 50;
        private string Value { get; set; }
        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new EmptyStringException("The password cannot be empty");
            }
            if(password.Length < ValueMinLength)
            {
                throw new InvalidLengthException($"The password should be minimum {ValueMinLength} characters long");
            }
            if (password.Length > ValueMaxLength)
            {
                throw new InvalidLengthException($"The password should be maximum {ValueMaxLength} characters long");
            }
            Value = password;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Password(string value)
        {
            return new Password(value);
        }
        public static implicit operator string(Password password)
        {
            return password.Value;
        }
    }
}
