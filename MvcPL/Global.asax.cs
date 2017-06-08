using ORM;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ORM.Entities;

namespace MvcPL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //IQueryable<Field> query;
            //using (var ctx = new EntityModel())
            //{
            //    query = ctx.Fields;
            //}
            //var count = query.Count();
        }
    }
}
