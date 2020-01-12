using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using MediatR;

namespace Alinta.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
