using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork.EF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IDomainEntity
    {
        private readonly UnitOfWork unitOfWork;

        public Repository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            this.unitOfWork.OpenTransaction();
            this.unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.unitOfWork.OpenTransaction();
            this.unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            this.unitOfWork.OpenTransaction();
            return this.unitOfWork.Context.Set<TEntity>().ToList();
        }
    }
}
