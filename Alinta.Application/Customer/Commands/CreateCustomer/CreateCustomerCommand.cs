using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using MediatR;

namespace Alinta.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
