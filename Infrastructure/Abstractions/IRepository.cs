using System.Collections.Generic;
using Infrastructure.Entities;

namespace Infrastructure.Abstractions
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity Add(TEntity entity);

        int Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}