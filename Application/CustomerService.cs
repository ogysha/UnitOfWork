using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Abstractions;
using Infrastructure.Entities;

namespace Application
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _repositoryCustomer;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork uow, IRepository<Customer> repositoryCustomer)
        {
            _unitOfWork = uow;
            _repositoryCustomer = repositoryCustomer;
        }

        public CustomerDto Add(string firstName, string lastName)
        {
            var existingWithSameName = _repositoryCustomer.GetAll()
                .Count(customer => customer.FirstName == firstName && customer.LastName == lastName);

            if (existingWithSameName != 0)
                throw new NotImplementedException("User already exists with this name");

            var customerNew = new Customer(firstName, lastName);

            _repositoryCustomer.Add(customerNew);
            _unitOfWork.Commit();

            return new CustomerDto(customerNew.Id, customerNew.FirstName, customerNew.LastName);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return _repositoryCustomer.GetAll()
                .Select(c => new CustomerDto(c.Id, c.FirstName, c.LastName));
        }
    }
}