using NPoco;

namespace UnitOfWork.NPoco
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabase db;

        public UnitOfWork(IDatabase db)
        {
            this.db = db;
        }

        public void Commit()
        {
            this.db.CompleteTransaction();
        }

        public void Rollback()
        {
            this.db.AbortTransaction();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}