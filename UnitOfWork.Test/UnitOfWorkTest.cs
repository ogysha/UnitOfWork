using NHibernate;
using UnitOfWork.NH;
using Xunit;

namespace UnitOfWork.Test
{
    public class UnitOfWorkTest
    {
        [Fact]
        public void NHConfigurationSingleton_SingleCall_ConfigurationIsReturned()
        {
            NHibernate.Cfg.Configuration config = ConfigurationSingleton.Configuration;
            Assert.NotNull(config);
        }

        [Fact]
        public void NHConfigurationSingleton_SeveralCalls_ConfigurationIsReturned()
        {
            NHibernate.Cfg.Configuration config = ConfigurationSingleton.Configuration;
            config = ConfigurationSingleton.Configuration;
            Assert.NotNull(config);
        }

        [Fact]
        public void NHSessionFactorySingleton_SingleCall_SessionFactoryIsReturned()
        {
            ISessionFactory sessionFactory = SessionFactorySingleton.SessionFactory;
            Assert.NotNull(sessionFactory);
        }
    }
}