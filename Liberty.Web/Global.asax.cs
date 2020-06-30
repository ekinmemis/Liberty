using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static Liberty.Web.Infrastructure.CustomSearchModelBinding;

namespace LibertyAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinderProviders.BinderProviders.Insert(0, new DataTablesToObjectModelBinderProvider());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
