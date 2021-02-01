using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApi.Application.Users.Models
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressUpsertModel Address { get; set; }
        public bool? Married { get; set; }
        public bool? HasJob { get; set; }
        public decimal? MonthlySalary { get; set; }
    }
}
