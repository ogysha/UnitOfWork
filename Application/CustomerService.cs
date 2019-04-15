using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;
using UnitOfWork.EF;

namespace Application
{
    public class CustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Customer> repositoryCustomer;

        public CustomerService(IUnitOfWork uow, IRepository<Customer> repositoryCustomer)
        {
            this.unitOfWork = uow;
            this.repositoryCustomer = repositoryCustomer;
        }

        public CustomerDto Add(string firstName, string lastName)
        {
            int existingWithSameName = this.repositoryCustomer.GetAll()
                .Count(customer => customer.FirstName == firstName && customer.LastName == lastName);

            if (existingWithSameName != 0)
                throw new NotImplementedException("User already exists with this name");

            Customer customerNew = new Customer(firstName, lastName);

            this.repositoryCustomer.Add(customerNew);
            this.unitOfWork.Commit();

            return new CustomerDto(customerNew.Id, customerNew.FirstName, customerNew.LastName);
        }

        public IEnumerable<CustomerDto> GetAll()
            => this.repositoryCustomer.GetAll()
                .Select(c => new CustomerDto(c.Id, c.FirstName, c.LastName));
    }
}
