using System;

namespace Infrastructure.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}