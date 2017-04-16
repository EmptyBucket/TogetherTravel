using DataBase;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using TogetherTravel;

[assembly: OwinStartup(typeof(Startup))]
namespace TogetherTravel
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext(() => new TogetherTravelContext());
            appBuilder.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            appBuilder.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
            //appBuilder.MapSignalR();
        }
    }
}