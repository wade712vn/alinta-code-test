using System;
using System.Threading;
using System.Threading.Tasks;
using Alinta.Application.Common.Exceptions;
using Alinta.Domain.Entities;
using Alinta.Infrastructure.Ef;
using MediatR;

namespace Alinta.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly AlintaContext _context;

        public UpdateCustomerCommandHandler(AlintaContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Dob = request.Dob;

            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}