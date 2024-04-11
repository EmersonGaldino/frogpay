using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

namespace frogpay.domain.Repositories.IRepository.Store;

public interface IStoreRepository
{
    Task<StoreEntity> GetStore(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateStore(StoreEntity model);
    Task<StoreEntity> UpdateStore(StoreEntity map);
    Task<StoreEntity> GetStoreByUserId(Guid userId);
    Task<bool> DeleteStore(Guid account_id);
}