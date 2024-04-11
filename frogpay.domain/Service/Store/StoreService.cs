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

    public Task<StoreEntity> UpdateAccount(StoreEntity map, Guid account_id)
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