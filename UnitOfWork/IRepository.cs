using System.Collections.Generic;

namespace UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : IDomainEntity
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}