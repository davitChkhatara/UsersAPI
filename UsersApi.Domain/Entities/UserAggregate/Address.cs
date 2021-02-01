using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Domain.Entities.UserAggregate
{
    public class Address 
    {
        public virtual int Id { get; protected set; }
        public string Street { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        private Address() 
        {

        }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public void UpdateAddress(string city, string street, string country)
        {
            City = string.IsNullOrEmpty(city) ? City : city;
            Country = string.IsNullOrEmpty(country) ? Country : country;
            Street = string.IsNullOrEmpty(street) ? Street : street;
        }
    }
}
