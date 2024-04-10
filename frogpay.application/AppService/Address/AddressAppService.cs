using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.application.Interface.Address;
using frogpay.domain.Entity.Address;

namespace frogpay.application.AppService.Address;

public class AddressAppService : IAddressAppService
{
    private readonly IAccountService service;
    public AddressAppService(IAccountService service)
    {
        this.service = service;
    }

    public Task<AddressEntity> GetAccount(AddressEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<AddressEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAccount(AddressEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<AddressEntity> UpdateAccount(AddressEntity map, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<AddressEntity> GetAccountByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Guid userId)
    {
        throw new NotImplementedException();
    }
}