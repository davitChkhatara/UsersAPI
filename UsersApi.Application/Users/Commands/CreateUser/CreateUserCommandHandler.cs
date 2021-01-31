using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName,
                                request.Email,
                                request.PersonalId,
                                new Address(request.Street,
                                            request.City,
                                            request.Country),
                                request.Married,
                                request.HasJob,
                                request.MonthlySalary);

            throw new NotImplementedException();
        }
    }
}
