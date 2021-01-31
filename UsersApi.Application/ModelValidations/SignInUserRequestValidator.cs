using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Application.Users.Models;

namespace UsersApi.Application.ModelValidations
{
    public class SignInUserRequestValidator : AbstractValidator<SignInUserRequest>
    {
        public SignInUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
