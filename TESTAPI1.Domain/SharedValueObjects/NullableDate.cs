using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI1.Domain.Models.Exceptions;

namespace TESTAPI1.Domain.SharedValueObjects
{
    public class NullableDate: ValueObject
    {
        private DateTime? value { get; set; }
        public NullableDate(DateTime? date)
        {
            if(date != null)
            {
                if (date.Value.Date > DateTime.UtcNow.Date)
                {
                    throw new InvalidDateException("Are you a time traveler? the date cannot be greater than today.");
                }
                value = date.Value.Date;
            }
            else
            {
                value = null;
            }
        }
        public static implicit operator NullableDate(DateTime? value)
        {
            return new NullableDate(value);
        }
        public static implicit operator DateTime?(NullableDate date)
        {
            if (date == null) 
            { 
                return null; 
            }
            return date.value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }
}
