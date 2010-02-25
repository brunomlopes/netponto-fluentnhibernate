using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using Model.Data;
using NHibernate;
using Spark;
using Spark.Web.Mvc;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            SetupSpark();

            SetupAutofac();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        private void SetupSpark()
        {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddAssembly("Web");

            ViewEngines.Engines.Add(new SparkViewFactory(settings));
        }

        private void SetupAutofac()
        {
            var databaseFile = Server.MapPath(@"~\app_data\database.db");
            var pathToNhConfig = Server.MapPath(@"~\nhibernate.config");

            var builder = new ContainerBuilder();

            builder
                .RegisterType<DataConfiguration>()
                .SingleInstance();

            builder
                .Register(
                    c =>
                    c.Resolve<DataConfiguration>(new Parameter[]
                                                     {
                                                         new NamedParameter("databaseFile", databaseFile),
                                                     })
                        .CreateSessionFactory())
                .As<ISessionFactory>()
                .SingleInstance();

            builder
               .Register(c => c.Resolve<ISessionFactory>().OpenSession())
               .As<ISession>()
               .HttpRequestScoped();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            _containerProvider = new ContainerProvider(builder.Build());

            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}