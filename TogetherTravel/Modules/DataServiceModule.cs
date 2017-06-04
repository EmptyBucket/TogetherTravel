using DataBase;
using DataBase.Models.User;
using DataBase.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace TogetherTravel.Modules
{
    public class DataServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<TogetherTravelContext>()
                .ToSelf()
                .InRequestScope();
            Bind<IDataService<User>>().To<UserDataService>()
                .InRequestScope();
        }
    }
}