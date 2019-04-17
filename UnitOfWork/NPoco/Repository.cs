using System.Collections.Generic;

namespace UnitOfWork.NPoco
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IDomainEntity
    {
        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}