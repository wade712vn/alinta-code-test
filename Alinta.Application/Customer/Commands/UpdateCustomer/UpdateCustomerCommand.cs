using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using MediatR;

namespace Alinta.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
