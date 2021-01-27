using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Interfaces;

namespace UsersApi.Domain.Entities
{
    public class User : IdentityUser<int>, IAggregateRoot
    {
        public string PersonalId { get; set; }
        public bool Married { get; set; }
        public bool HasJob { get; set; }
        public decimal? MonthlySalary { get; set; }
    }
}
