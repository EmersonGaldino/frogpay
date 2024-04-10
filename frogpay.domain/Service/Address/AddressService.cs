using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Repositories.IRepository.Account;
using frogpay.domain.Repositories.IRepository.Address;

namespace frogpay.domain.Service.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository repository;
    public AddressService(IAddressRepository repository)
    {
        this.repository = repository;
    }

    public Task<AddressEntity> GetAddress(AddressEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<DataBankEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAddress(AddressEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<AddressEntity> UpdateAddress(AddressEntity map, Guid account_id)
    {
        throw new NotImplementedException();
    }

    public Task<AddressEntity> GetAddressByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAddress(Guid account_id)
    {
        throw new NotImplementedException();
    }
}