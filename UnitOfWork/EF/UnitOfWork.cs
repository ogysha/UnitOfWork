using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace UnitOfWork.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction Transaction { get; set; }
        public DbContext Context { get; private set; }

        public UnitOfWork(ECommerceContext context)
        {
            this.Context = context;
        }

        public void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.Transaction == null)
            {
                this.Transaction = this.Context.Database.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                this.Context.SaveChanges();
                this.Transaction.Commit();
            }
            catch
            {
                this.Transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            this.Transaction.Rollback();
        }

        public void Dispose()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }

            this.Context.Dispose();
        }
    }
}