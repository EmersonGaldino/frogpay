using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;
using frogpay.domain.Repositories.IRepository.Store;
using frogpay.repository.context;

namespace frogpay.repository.Store;

public class StoreRepository : BaseRepository<StoreEntity>, IStoreRepository
{
    private readonly ContextDb context;
    public StoreRepository(ContextDb context) : base(context)
    {
        this.context = context;
    }


    public Task<StoreEntity> GetStore(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<StoreEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateStore(StoreEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> UpdateStore(StoreEntity map)
    {
        throw new NotImplementedException();
    }

    public Task<StoreEntity> GetStoreByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteStore(Guid account_id)
    {
        throw new NotImplementedException();
    }
}