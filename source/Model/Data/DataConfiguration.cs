using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Model.Mappings;
using NHibernate;
using NHibernate.Cfg;

namespace Model.Data
{
    public class DataConfiguration
    {
        private Configuration _configuration;
        private FluentConfiguration _fluentConfiguration;

        public DataConfiguration(string databaseFile)
        {
            NHibernateProfiler.Initialize();
            _fluentConfiguration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(databaseFile)
                        .AdoNetBatchSize(16)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CasaMap>());

            _configuration = _fluentConfiguration
                .BuildConfiguration();
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }
        public FluentConfiguration GetFluentConfiguration()
        {
            return _fluentConfiguration;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return _configuration.BuildSessionFactory();
        }
    }
}