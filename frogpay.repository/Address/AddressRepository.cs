using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Repositories.IRepository.Address;
using frogpay.repository.context;

namespace frogpay.repository.Address;

public class AddressRepository : IAddressRepository
{
    private readonly ContextDb context;
    public AddressRepository(ContextDb context)
    {
        this.context = context;
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

    public Task<DataBankEntity> UpdateAddress(AddressEntity map)
    {
        throw new NotImplementedException();
    }

    public Task<DataBankEntity> GetAddressByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAddress(Guid account_id)
    {
        throw new NotImplementedException();
    }
}