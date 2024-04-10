using AutoMapper;
using frogpay.api.rest.Models.Store;
using frogpay.api.rest.Models.User;
using frogpay.domain.Entity.Store;
using frogpay.domain.Entity.User;

namespace frogpay.api.rest.AutoMapper
{
    public class MappingProfilesModelView : Profile
    {
        public MappingProfilesModelView()
        {

            CreateMap<UserEntity, UserModelView>().ReverseMap();
            CreateMap<StoreEntity, StoreModelView>().ReverseMap();
            CreateMap<UserEntity, UserViewModel>().ReverseMap();
        }
    }
}