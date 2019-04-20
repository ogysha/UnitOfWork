using System;

namespace Infrastructure.Entities
{
    public class Customer : IEntity
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public Guid Id { get; }
        public DateTime Created { get; }
        public DateTime LastUpdate { get; }
    }
}