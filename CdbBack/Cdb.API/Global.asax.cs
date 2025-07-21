using Autofac;
using Autofac.Integration.WebApi;
using Cdb.API;
using Cdb.App.Handler;
using Cdb.App.Interfaces;
using Cdb.Domain.Interfaces;
using Cdb.Domain.Services;
using System.Reflection;
using System.Web.Http;

namespace CdbAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            // Registre os controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Registre suas dependências
            builder.RegisterType<CdbHandler>().As<ICdbHandler>().InstancePerRequest(); 
            builder.RegisterType<CdbCalculatorService>().As<ICdbCalculatorService>().InstancePerRequest();

            // Construa o container
            var container = builder.Build();

            // Configure o resolver de dependência
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Configuração padrão do Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
