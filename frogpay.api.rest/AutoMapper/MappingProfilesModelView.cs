using AutoMapper;
using frogpay.api.rest.Models.Account;
using frogpay.api.rest.Models.Address;
using frogpay.api.rest.Models.Pagination;
using frogpay.api.rest.Models.Store;
using frogpay.api.rest.Models.User;
using frogpay.domain.Entity.Address;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Entity.Pagination;
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
            CreateMap<StoreEntity, StoreViewModel>().ReverseMap();
            CreateMap<UserEntity, UserViewModel>().ReverseMap();
            CreateMap<DataBankEntity, AccountModelView>().ReverseMap();
            CreateMap<DataBankEntity, AccountViewModel>().ReverseMap();
            CreateMap<AddressEntity, AddressModelView>().ReverseMap();
            CreateMap<AddressEntity, AddressViewModel>().ReverseMap();
            CreateMap<PaginationEntity<StoreEntity>, PaginationModelView<StoreViewModel>>().ReverseMap();
        }
    }
}