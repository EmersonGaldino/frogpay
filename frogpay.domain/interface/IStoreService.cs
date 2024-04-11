
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

public interface IStoreService
{
    Task<StoreEntity> GetStore(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateStore(StoreEntity model);
    Task<StoreEntity> UpdateStore(StoreEntity map, Guid account_id);
    Task<List<StoreEntity>> GetStoreByUserId(Guid userId);
    Task<bool> DeleteStore(Guid account_id);
}
