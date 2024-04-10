using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;

namespace frogpay.application.Interface.Address;

public interface IAddressAppService
{
    Task<AddressEntity> GetAddress(AddressEntity model);
    Task<List<AddressEntity>> GetAll();
    Task<bool> CreateAddress(AddressEntity model);
    Task<AddressEntity> UpdateAddress(AddressEntity map, Guid userId);
    Task<AddressEntity> GetAddressByUserId(Guid userId);
    Task<bool> DeleteAddress(Guid userId);
}