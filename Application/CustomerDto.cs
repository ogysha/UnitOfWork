using System;

namespace Application
{
    public class CustomerDto
    {
        private Guid Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }

        public CustomerDto(Guid id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
            => $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
    }
}