using System;
using System.Threading;
using System.Threading.Tasks;
using Alinta.Application.Common.Exceptions;
using Alinta.Domain.Entities;
using Alinta.Infrastructure.Ef;
using MediatR;

namespace Alinta.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly AlintaContext _context;

        public DeleteCustomerCommandHandler(AlintaContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}