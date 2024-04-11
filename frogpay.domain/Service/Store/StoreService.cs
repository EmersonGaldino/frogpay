using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;
using frogpay.domain.Repositories.IRepository.Store;

namespace frogpay.domain.Service.Store;

public class StoreService : IStoreService
{
    private readonly IStoreRepository repository;
    public StoreService(IStoreRepository repository)
    {
        this.repository = repository;
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

    public Task<StoreEntity> UpdateStore(StoreEntity map, Guid account_id)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> GetStoreByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteStore(Guid account_id)
    {
        throw new NotImplementedException();
    }
}