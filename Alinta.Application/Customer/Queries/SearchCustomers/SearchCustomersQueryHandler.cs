using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alinta.Domain.Entities;
using Alinta.Infrastructure.Ef;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alinta.Application.Queries.SearchCustomers
{
    public class SearchCustomersQueryHandler : IRequestHandler<SearchCustomersQuery, IEnumerable<Customer>>
    {
        private readonly AlintaContext _context;

        public SearchCustomersQueryHandler(AlintaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = string.IsNullOrWhiteSpace(request.Search) ? 
                _context.Customers : 
                _context.Customers.Where(x => x.FirstName.Contains(request.Search) || x.LastName.Contains(request.Search));

            return await query.ToListAsync(cancellationToken);
        }
    }
}