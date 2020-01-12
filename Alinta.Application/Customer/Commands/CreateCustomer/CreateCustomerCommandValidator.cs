using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Application.Commands.CreateCustomer;
using FluentValidation;

namespace Alinta.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name must not be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name must not be empty");
        }
    }
}
