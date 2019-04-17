using NPoco;
using NSubstitute;
using Xunit;

namespace UnitOfWork.Test.NPoco
{
    public class UnitOfWorkShould
    {
        [Fact]
        public void Commit_changes_to_the_database()
        {
            var db = Substitute.For<IDatabase>();

            var uow = new UnitOfWork.NPoco.UnitOfWork(db);
            uow.Commit();

            db.Received(1).CompleteTransaction();
        }

        [Fact]
        public void Rollback_planned_changes_for_the_database()
        {
            var db = Substitute.For<IDatabase>();

            var uow = new UnitOfWork.NPoco.UnitOfWork(db);
            uow.Rollback();

            db.Received(1).AbortTransaction();
        }

        [Fact]
        public void Dispose_object_in_gracefull_way()
        {
            var db = Substitute.For<IDatabase>();

            using (var uow = new UnitOfWork.NPoco.UnitOfWork(db))
            {
            }

            db.Received(1).Dispose();
        }
    }
}