using System;

namespace UnitOfWork
{
    public interface IDomainEntity
    {
        Guid Id { get; }
    }
}