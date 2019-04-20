using System;

namespace Application
{
    public class CustomerDto
    {
        public CustomerDto(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        private Guid Id { get; }
        private string FirstName { get; }
        private string LastName { get; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
        }
    }
}