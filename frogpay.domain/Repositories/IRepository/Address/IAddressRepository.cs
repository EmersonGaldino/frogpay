using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Entity.Bank;

namespace frogpay.domain.Repositories.IRepository.Address;

public interface IAddressRepository
{
    Task<AddressEntity> GetAddress(AddressEntity model);
    Task<List<DataBankEntity>> GetAll();
    Task<bool> CreateAddress(AddressEntity model);
    Task<DataBankEntity> UpdateAddress(AddressEntity map);
    Task<DataBankEntity> GetAddressByUserId(Guid userId);
    Task<bool> DeleteAddress(Guid account_id);
}