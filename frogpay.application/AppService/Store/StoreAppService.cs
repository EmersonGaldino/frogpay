using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.application.Interface.Store;
using frogpay.domain.Entity.Store;

namespace frogpay.application.AppService.Store;

public class StoreAppService : IStoreAppService
{
    private readonly IStoreService service;
    public StoreAppService(IStoreService service)
    {
        this.service = service;
    }

    public async Task<StoreEntity> GetStore(StoreEntity model) => await service.GetStore(model);
    
    public async Task<List<StoreEntity>> GetAll() => await service.GetAll();
    
    public async Task<bool> CreateStore(StoreEntity model) => await service.CreateStore(model);
    
    public async Task<StoreEntity> UpdateStore(StoreEntity map, Guid userId) => await service.UpdateStore(map, userId);
    
    public async Task<StoreEntity> GetStoreByUserId(Guid userId) => await service.GetStoreByUserId(userId);
    
    public async Task<bool> DeleteStore(Guid userId) => await service.DeleteStore(userId);
}