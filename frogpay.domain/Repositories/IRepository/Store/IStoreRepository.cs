using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;

namespace frogpay.domain.Repositories.IRepository.Store;

public interface IStoreRepository
{
    Task<StoreEntity> GetAccount(StoreEntity model);
    Task<List<StoreEntity>> GetAll();
    Task<bool> CreateAccount(StoreEntity model);
    Task<StoreEntity> UpdateAccount(StoreEntity map);
    Task<StoreEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid account_id);
}