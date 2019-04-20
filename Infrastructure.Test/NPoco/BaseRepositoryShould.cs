using System.Collections.Generic;
using System.Linq;
using Infrastructure.Entities;
using Infrastructure.Repositories.NPoco;
using NPoco;
using NSubstitute;
using Xunit;

namespace Infrastructure.Test.NPoco
{
    public class BaseRepositoryShould
    {
        public BaseRepositoryShould()
        {
            _db = Substitute.For<IDatabase>();
            _unitOfWork = Substitute.For<Repositories.NPoco.UnitOfWork>(_db);

            _repository = new BaseRepository<Customer>(_unitOfWork);
        }

        private readonly BaseRepository<Customer> _repository;
        private readonly Repositories.NPoco.UnitOfWork _unitOfWork;
        private readonly IDatabase _db;

        private IEnumerable<Customer> GetCustomers()
        {
            yield return new Customer("John", "Smith");
            yield return new Customer("Marry", "Be");
        }

        [Fact]
        public void Add_new_entity_to_database()
        {
            _db.Insert(Arg.Any<Customer>());

            var customer = new Customer("John", "Smith");
            _repository.Add(customer);

            _unitOfWork.Database.Received(1).Insert(customer);
        }

        [Fact]
        public void Get_all_entities_from_database()
        {
            _db.Query<Customer>(Arg.Any<Sql>()).Returns(GetCustomers());
            var customers = _repository.GetAll();

            Assert.Equal(2, customers.Count());

            _unitOfWork.Database.Received(1).Query<Customer>(Arg.Any<Sql>());
        }

        [Fact]
        public void Remove_existing_entity_from_database()
        {
            _db.Delete(Arg.Any<Customer>()).Returns(1);

            var customer = new Customer("John", "Smith");
            _repository.Add(customer);

            var rows = _repository.Remove(customer);

            Assert.Equal(1, rows);
            _unitOfWork.Database.Received(1).Delete(customer);
        }
    }
}