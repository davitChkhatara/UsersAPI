using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Users.Models
{
    public class AddressUpsertModel
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
