using Infrastructure.Abstractions;
using NPoco;

namespace Infrastructure.Repositories.NPoco
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;

        public UnitOfWork(IDatabase db)
        {
            Database = db;
        }

        public IDatabase Database { get; }

        public void Commit()
        {
            Database.CompleteTransaction();
        }

        public void Rollback()
        {
            Database.AbortTransaction();
        }

        public void Dispose()
        {
            Database?.Dispose();
        }

        public void OpenTransaction()
        {
            if (_transaction != null) return;

            Database.BeginTransaction();

            _transaction = Database.GetTransaction();
        }
    }
}