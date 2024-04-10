using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Repositories.IRepository.Address;

namespace frogpay.domain.Service.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository repository;
    public AddressService(IAddressRepository repository)
    {
        this.repository = repository;
    }

    public async Task<AddressEntity> GetAddress(AddressEntity model)
    {
        var account = await GetAddressByUserId(model.UserId);
        return account == null ? null : await repository.GetAddress(model);
    }

    public async Task<List<AddressEntity>> GetAll() => await repository.GetAll();


    public async Task<bool> CreateAddress(AddressEntity model)
    {
        var account = await GetAddressByUserId(model.UserId);
        return account != null ? false : await repository.CreateAddress(model);
    }

    public async Task<AddressEntity> UpdateAddress(AddressEntity map, Guid account_id)
    {
        map.id = account_id;
        return await repository.UpdateAddress(map);
    }
    
    public async Task<AddressEntity> GetAddressByUserId(Guid userId) => await repository.GetAddressByUserId(userId);

    public async Task<bool> DeleteAddress(Guid account_id) =>
        await repository.DeleteAddress(account_id);
}