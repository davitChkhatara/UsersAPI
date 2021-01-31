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
    }
}
