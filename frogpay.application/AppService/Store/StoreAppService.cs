using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.application.Interface.Store;
using frogpay.domain.Entity.Store;

namespace frogpay.application.AppService.Store;

public class StoreAppService : IStoreAppService
{
    public Task<StoreEntity> GetAccount(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<StoreEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAccount(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> UpdateAccount(StoreEntity map, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> GetAccountByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Guid userId)
    {
        throw new NotImplementedException();
    }
}