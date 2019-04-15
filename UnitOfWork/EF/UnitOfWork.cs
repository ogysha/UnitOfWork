using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace UnitOfWork.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction Transaction { get; set; }
        public DbContext Context { get; }

        public UnitOfWork(ECommerceContext context)
        {
            Context = context;
        }

        public void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Transaction == null) Transaction = Context.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            Context.Dispose();
        }
    }
}