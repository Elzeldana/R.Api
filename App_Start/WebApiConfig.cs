using Autofac;
using HranaLibrary.Repository;
using HranaLibrary.Services;
using log4net;
using System.Reflection;
using Autofac.Integration.WebApi;
using System.Web.Http;
namespace HranaApi
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            var builder = new ContainerBuilder();

            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<DataRepo>().As<IDataRepo>();
            builder.RegisterType<RecipeService>().As<IRecipeService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}