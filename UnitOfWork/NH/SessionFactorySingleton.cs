using NHibernate;

namespace UnitOfWork.NH
{
    public static class SessionFactorySingleton
    {
        private static ISessionFactory sessionFactory = null;
        private static object lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObj)
                {
                    if (sessionFactory == null)
                    {
                        sessionFactory = ConfigurationSingleton.Configuration.BuildSessionFactory();
                    }
                }

                return sessionFactory;
            }
        }
    }
}