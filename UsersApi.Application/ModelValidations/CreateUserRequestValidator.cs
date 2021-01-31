using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Application.Users.Models;

namespace UsersApi.Application.ModelValidations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.PersonalId).NotNull().NotEmpty();
            When(c => c.Address != null, () =>
            {
                RuleFor(x => x.Address.City).NotNull().NotEmpty();
                RuleFor(x => x.Address.Country).NotNull().NotEmpty();
                RuleFor(x => x.Address.Street).NotNull().NotEmpty();
                       
            });
            When(c => c.HasJob.HasValue && c.HasJob.Value, () =>
            {
                RuleFor(x => x.MonthlySalary).NotNull().GreaterThan(0);
            });
        }
    }
}
