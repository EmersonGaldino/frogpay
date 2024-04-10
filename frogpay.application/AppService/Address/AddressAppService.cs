using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.application.Interface.Address;
using frogpay.domain.Entity.Address;

namespace frogpay.application.AppService.Address;

public class AddressAppService : IAddressAppService
{
    private readonly IAddressService service;
    public AddressAppService(IAddressService service)
    {
        this.service = service;
    }
    public async Task<AddressEntity> GetAddress(AddressEntity model) => await service.GetAddress(model);
    
    public async Task<List<AddressEntity>> GetAll() => await service.GetAll();
    
    public async Task<bool> CreateAddress(AddressEntity model) => await service.CreateAddress(model);
    
    public async Task<AddressEntity> UpdateAddress(AddressEntity map, Guid userId) => await service.UpdateAddress(map, userId);
    
    public async Task<AddressEntity> GetAddressByUserId(Guid userId) => await service.GetAddressByUserId(userId);
    
    public async Task<bool> DeleteAddress(Guid userId) => await service.DeleteAddress(userId);
}