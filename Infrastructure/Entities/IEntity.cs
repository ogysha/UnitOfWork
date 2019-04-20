using System;

namespace Infrastructure.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime Created { get; }
        DateTime LastUpdate { get; }
    }
}