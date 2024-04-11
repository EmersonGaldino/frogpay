using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

namespace frogpay.application.Interface.Store;

public interface IStoreAppService
{
    Task<StoreEntity> GetStore(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateStore(StoreEntity model);
    Task<StoreEntity> UpdateStore(StoreEntity map, Guid userId);
    Task<StoreEntity> GetStoreByUserId(Guid userId);
    Task<bool> DeleteStore(Guid userId);
}