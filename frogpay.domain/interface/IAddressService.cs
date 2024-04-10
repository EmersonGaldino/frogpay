using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Entity.Bank;


public interface IAddressService
{
    Task<AddressEntity> GetAddress(AddressEntity model);
    Task<List<DataBankEntity>> GetAll();
    Task<bool> CreateAddress(AddressEntity model);
    Task<AddressEntity> UpdateAddress(AddressEntity map, Guid account_id);
    Task<AddressEntity> GetAddressByUserId(Guid userId);
    Task<bool> DeleteAddress(Guid account_id);
}