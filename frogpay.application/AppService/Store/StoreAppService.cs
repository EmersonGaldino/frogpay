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

    public Task<StoreEntity> GetStore(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<StoreEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateStore(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> UpdateStore(StoreEntity map, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> GetStoreByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteStore(Guid userId)
    {
        throw new NotImplementedException();
    }
}