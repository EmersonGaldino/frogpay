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

    public async Task<StoreEntity> GetStore(StoreEntity model)
    {
        var Store = await GetStoreByUserId(model.UserId);
        return Store == null ? null : await repository.GetStore(model);
    }

    public async Task<List<StoreEntity>> GetAll() => await repository.GetAll();


    public async Task<bool> CreateStore(StoreEntity model)
    {
        var store = await GetStoreByUserId(model.UserId);
        return store != null ? false : await repository.CreateStore(model);
    }

    public async Task<StoreEntity> UpdateStore(StoreEntity map, Guid Store_id)
    {
        map.id = Store_id;
        return await repository.UpdateStore(map);
    }
    
    public async Task<List<StoreEntity>> GetStoreByUserId(Guid userId) => await repository.GetStoreByUserId(userId);

    public async Task<bool> DeleteStore(Guid Store_id) =>
        await repository.DeleteStore(Store_id);
}