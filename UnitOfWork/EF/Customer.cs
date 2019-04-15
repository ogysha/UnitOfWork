using System;

namespace UnitOfWork.EF
{
    public class Customer : IDomainEntity
    {
        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}