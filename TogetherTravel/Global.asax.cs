using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DataBase;
using TogetherTravel.Migrations;

namespace TogetherTravel
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.BundlesRegister(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TogetherTravelContext, Configuration>());
            AssetsProvider.Bind(Server.MapPath("~/webpack-assets.json"));
        }
    }
}