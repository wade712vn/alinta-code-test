using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using MediatR;

namespace Alinta.Application.Queries.SearchCustomers
{
    public class SearchCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public SearchCustomersQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
