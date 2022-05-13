using TESTAPI1.Domain.Models.Exceptions;

namespace TESTAPI1.Domain.SharedValueObjects
{
    public class Date: ValueObject
    {
        private DateTime value { get; set; }
        public Date(DateTime date)
        {
            if(date.Date > DateTime.UtcNow.Date )
            {
                throw new InvalidDateException("Are you a time traveler? the date cannot be greater than today.");
            }
            value = date;
        }
        public static implicit operator Date(DateTime value)
        {
            return new Date(value);
        }
        public static implicit operator DateTime(Date creationDate)
        {
            return creationDate.value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }
}
