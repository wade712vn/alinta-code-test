using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alinta.Infrastructure.Ef
{
    public class AlintaContext : DbContext
    {
        public AlintaContext(DbContextOptions<AlintaContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
