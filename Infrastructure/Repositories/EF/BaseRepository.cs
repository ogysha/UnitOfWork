using System.Collections.Generic;
using System.Linq;
using Infrastructure.Abstractions;
using Infrastructure.Entities;

namespace Infrastructure.Repositories.EF
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly UnitOfWork _unitOfWork;

        public BaseRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TEntity Add(TEntity entity)
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.Context.Set<TEntity>().Add(entity).Entity;
        }

        public int Remove(TEntity entity)
        {
            _unitOfWork.OpenTransaction();
            var deleted = _unitOfWork.Context.Set<TEntity>().Remove(entity).Entity;

            return deleted != null ? 1 : 0;
        }

        public IEnumerable<TEntity> GetAll()
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.Context.Set<TEntity>().ToList();
        }
    }
}