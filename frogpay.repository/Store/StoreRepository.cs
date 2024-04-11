using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;
using frogpay.domain.Repositories.IRepository.Store;
using frogpay.repository.context;

namespace frogpay.repository.Store;

public class StoreRepository : IStoreRepository
{
    private readonly ContextDb context;
    public StoreRepository(ContextDb context)
    {
        this.context = context;
    }

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

    public Task<StoreEntity> UpdateAccount(StoreEntity map)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> GetAccountByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Guid account_id)
    {
        throw new NotImplementedException();
    }
}