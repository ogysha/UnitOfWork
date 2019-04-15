using NHibernate.Cfg;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace UnitOfWork.NH
{
    public static class ConfigurationSingleton
    {
        private static Configuration configuration = null;
        private static object lockObj = new object();

        public static Configuration Configuration
        {
            get
            {
                lock (lockObj)
                {
                    if (configuration != null)
                    {
                        return configuration;
                    }

                    string[] resourceNames;
                    string nHResource = string.Empty;
                    Assembly[] asmArray = AppDomain.CurrentDomain.GetAssemblies();

                    foreach (Assembly asm in asmArray)
                    {
                        resourceNames = asm.GetManifestResourceNames();
                        nHResource = resourceNames.FirstOrDefault(x => x.ToLower().Contains("hibernate.config"));

                        if (!string.IsNullOrEmpty(nHResource))
                        {
                            using (Stream resxStream = asm.GetManifestResourceStream(nHResource))
                            {
                                configuration = new Configuration();
                                configuration.Configure(new XmlTextReader(resxStream));
                            }
                        }
                    }

                    return configuration;
                }
            }
        }
    }
}