
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

public interface IStoreService
{
    Task<StoreEntity> GetAccount(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateAccount(StoreEntity model);
    Task<StoreEntity> UpdateAccount(StoreEntity map, Guid account_id);
    Task<StoreEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid account_id);
}