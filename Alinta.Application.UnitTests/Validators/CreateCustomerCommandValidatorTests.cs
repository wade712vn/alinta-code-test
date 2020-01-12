using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Application.Commands.CreateCustomer;
using FluentValidation.TestHelper;
using Xunit;

namespace Alinta.Application.UnitTests.Validators
{
    public class CreateCustomerCommandValidatorTests
    {
        [Fact]
        public void CreateCustomerCommand_EmptyFirstName_ReturnError()
        {
            var command = new CreateCustomerCommand()
            {
                FirstName = string.Empty,
                LastName = "Kent",
                Dob = new DateTime(1990, 1, 2)
            };

            var validator = new CreateCustomerCommandValidator();

            validator.ShouldHaveValidationErrorFor(x => x.FirstName, command);
        }
    }
}
