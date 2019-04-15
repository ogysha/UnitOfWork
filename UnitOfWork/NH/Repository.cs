using System.Collections.Generic;

namespace UnitOfWork.NH
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IDomainEntity
    {
        private readonly UnitOfWork nhUnitOfWork;

        public Repository(UnitOfWork nhUnitOfWork)
        {
            this.nhUnitOfWork = nhUnitOfWork;
        }

        public void Add(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Save(entity);
        }

        public void Remove(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();
            this.nhUnitOfWork.Session.Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            this.nhUnitOfWork.OpenSession();
            this.nhUnitOfWork.BeginTransation();

            return this.nhUnitOfWork.Session.Query<TEntity>();
        }
    }
}