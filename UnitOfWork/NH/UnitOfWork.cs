using NHibernate;
using System.Data;

namespace UnitOfWork.NH
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction transaction;
        public ISession Session { get; private set; }

        public void OpenSession()
        {
            if (this.Session == null || !this.Session.IsConnected)
            {
                if (this.Session != null)
                    this.Session.Dispose();

                this.Session = SessionFactorySingleton.SessionFactory.OpenSession();
            }
        }

        public void BeginTransation(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (this.transaction == null || !this.transaction.IsActive)
            {
                if (this.transaction != null)
                    this.transaction.Dispose();

                this.transaction = this.Session.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                this.transaction.Commit();
            }
            catch
            {
                this.transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
                this.transaction = null;
            }

            if (this.Session != null)
            {
                this.Session.Close();
                this.Session.Dispose();
                this.Session = null;
            }
        }
    }
}