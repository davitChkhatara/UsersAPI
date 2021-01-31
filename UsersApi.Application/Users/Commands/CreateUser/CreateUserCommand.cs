using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string PersonalId { get; set; }
        public bool Married { get; set; }
        public bool HasJob { get; set; }
        public decimal? MonthlySalary { get; set; }
        public Address Address { get; set; }
        public string UserName  { get; set;}
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

    }
}
