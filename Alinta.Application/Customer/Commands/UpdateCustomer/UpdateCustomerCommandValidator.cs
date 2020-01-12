using Alinta.Application.Commands.CreateCustomer;
using FluentValidation;

namespace Alinta.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name must not be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name must not be empty");
        }
    }
}
