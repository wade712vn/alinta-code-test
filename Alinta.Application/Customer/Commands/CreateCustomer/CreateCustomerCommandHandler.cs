using System;
using System.Threading;
using System.Threading.Tasks;
using Alinta.Domain.Entities;
using Alinta.Infrastructure.Ef;
using MediatR;

namespace Alinta.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly AlintaContext _context;

        public CreateCustomerCommandHandler(AlintaContext context)
        {
            _context = context;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(
                request.FirstName,
                request.LastName,
                request.Dob
            );

            _context.Add(customer);

            await _context.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}