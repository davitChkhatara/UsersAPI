using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Entities;

namespace UsersApi.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequest<User>
    {

    }
}
