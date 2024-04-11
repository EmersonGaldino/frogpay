using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

namespace frogpay.application.Interface.Store;

public interface IStoreAppService
{
    Task<StoreEntity> GetAccount(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateAccount(StoreEntity model);
    Task<StoreEntity> UpdateAccount(StoreEntity map, Guid userId);
    Task<StoreEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid userId);
}