using AutoMapper;
using DataBase.Models.User;
using TogetherTravel.ViewModels;

namespace TogetherTravel.Mappers
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<RegistrationUserViewModel, User>()
                .ForMember(user => user.UserName, expression => expression.ResolveUsing(model => model.UserName));
        }
    }
}