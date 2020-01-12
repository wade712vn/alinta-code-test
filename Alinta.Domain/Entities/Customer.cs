using System;
using System.Collections.Generic;
using System.Text;

namespace Alinta.Domain.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
