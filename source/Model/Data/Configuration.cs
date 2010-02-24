using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Model.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Model.Data
{
    public class Configuration
    {
        private static FluentConfiguration _configuration;

        public Configuration(string databaseFile)
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            _configuration = Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(databaseFile)
                )
                .Mappings(m => 
                          m.AutoMappings.Add(AutoMap.AssemblyOf<Casa>().Where(t => t.Namespace.EndsWith("Entities"))));
            
        }

        public FluentConfiguration FluentConfiguration
        {
            get { return _configuration; }
        }

        public ISessionFactory CreateSessionFactory()
        {
            return FluentConfiguration
                .BuildSessionFactory();
        }
    }
}