using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Model.Entities;
using NHibernate;
using NHibernate.Cfg;

namespace Model.Data
{
    public class DataConfiguration
    {
        private Configuration _configuration;

        public DataConfiguration(string databaseFile)
        {
            NHibernateProfiler.Initialize();
            _configuration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(databaseFile)
                )
                .Mappings(m => m.HbmMappings.AddFromAssemblyOf<Casa>())
                .BuildConfiguration();
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