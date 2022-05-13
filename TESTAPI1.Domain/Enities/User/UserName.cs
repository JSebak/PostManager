using TESTAPI1.Domain.Models.Exceptions;
using TESTAPI1.Domain.SharedValueObjects;

namespace TESTAPI1.Domain.Enities.User
{
    //public readonly struct Username
    //{
    //    public string Name { get; }
    //    public static Username Create(string name) => new(name);

    //    private Username(string name)
    //    {
    //        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(Name));
    //        if (name.Length > 20) throw new ArgumentException("Username too long");
    //        if (name.Length < 2) throw new ArgumentException("Username too short");
    //        Name = name;
    //    }
    //}
    public class Username :ValueObject
    {
        private int MaxLength = 150;
        private string value { get; set; }

        public Username(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new EmptyStringException("The username cannot be empty");
            }
            if (username.Length > MaxLength)
            {
                throw new InvalidLengthException($"Exceeded maximum length of {MaxLength} characters");
            }
            value = username;
        }
        public static implicit operator Username(string value)
        {
            return new Username(value);
        }
        public static implicit operator string(Username username)
        {
            return username.value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }

    }
}

