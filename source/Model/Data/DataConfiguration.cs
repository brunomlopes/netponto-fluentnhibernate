using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;

namespace Model.Data
{
    public class DataConfiguration
    {
        private Configuration _configuration;

        public DataConfiguration(string databaseFile, string pathToNhConfig)
        {
            NHibernateProfiler.Initialize();
            _configuration = new Configuration().Configure(pathToNhConfig);
            _configuration.SetProperty(Environment.ConnectionString,
                                       string.Format("Data Source={0}", databaseFile));
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return _configuration.BuildSessionFactory();
        }
    }
}