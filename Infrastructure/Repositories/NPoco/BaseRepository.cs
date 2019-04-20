using System.Collections.Generic;
using Infrastructure.Abstractions;
using Infrastructure.Entities;
using NPoco;

namespace Infrastructure.Repositories.NPoco
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
            return _unitOfWork.Database.Insert(entity) as TEntity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.Database.Query<TEntity>(Sql.Builder.From(nameof(TEntity)));
        }

        public int Remove(TEntity entity)
        {
            _unitOfWork.OpenTransaction();
            return _unitOfWork.Database.Delete(entity);
        }
    }
}