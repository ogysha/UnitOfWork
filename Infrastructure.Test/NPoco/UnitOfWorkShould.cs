using NPoco;
using NSubstitute;
using Xunit;

namespace Infrastructure.Test.NPoco
{
    public class UnitOfWorkShould
    {
        [Fact]
        public void Commit_changes_to_the_database()
        {
            var db = Substitute.For<IDatabase>();

            var uow = new Repositories.NPoco.UnitOfWork(db);
            uow.Commit();

            uow.Database.Received(1).CompleteTransaction();
        }

        [Fact]
        public void Dispose_object_in_graceful_way()
        {
            var db = Substitute.For<IDatabase>();

            using (var uow = new Repositories.NPoco.UnitOfWork(db))
            {
            }

            db.Received(1).Dispose();
        }

        [Fact]
        public void Dispose_object_in_graceful_way_if_no_db()
        {
            var uow = new Repositories.NPoco.UnitOfWork(null);
            uow.Dispose();

            Assert.Null(uow.Database);
        }

        [Fact]
        public void Rollback_planned_changes_for_the_database()
        {
            var db = Substitute.For<IDatabase>();

            var uow = new Repositories.NPoco.UnitOfWork(db);
            uow.Rollback();

            uow.Database.Received(1).AbortTransaction();
        }
    }
}