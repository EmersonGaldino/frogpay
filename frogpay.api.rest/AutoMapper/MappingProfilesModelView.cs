using AutoMapper;
using frogpay.api.rest.Models.User;
using frogpay.domain.Entity.User;

namespace frogpay.api.rest.AutoMapper
{
    public class MappingProfilesModelView : Profile
    {
        public MappingProfilesModelView()
        {

            CreateMap<UserEntity, UserModelView>().ReverseMap();
        }
    }
}