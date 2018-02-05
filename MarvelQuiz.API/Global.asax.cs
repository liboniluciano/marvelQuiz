using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace MarvelQuiz.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterDependences());
        }
    }
}
