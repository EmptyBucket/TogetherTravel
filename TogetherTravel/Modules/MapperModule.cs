using AutoMapper;
using Ninject.Modules;
using TogetherTravel.Controllers;
using TogetherTravel.Mappers;

namespace TogetherTravel.Modules
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>()
                .ToConstant(new MapperConfiguration(expression => expression
                    .AddProfiles(typeof(RegistrationProfile))).CreateMapper())
                .WhenInjectedInto<AccountController>();
        }
    }
}