using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;

namespace frogpay.application.Interface.Address;

public interface IAddressAppService
{
    Task<AddressEntity> GetAccount(AddressEntity model);
    Task<List<AddressEntity>> GetAll();
    Task<bool> CreateAccount(AddressEntity model);
    Task<AddressEntity> UpdateAccount(AddressEntity map, Guid userId);
    Task<AddressEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid userId);
}