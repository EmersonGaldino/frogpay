using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frogpay.domain.Entity.Store;
using frogpay.domain.Repositories.IRepository.Store;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.Store;

public class StoreRepository : BaseRepository<StoreEntity>, IStoreRepository
{
    private readonly ContextDb context;
    public StoreRepository(ContextDb context) : base(context)
    {
        this.context = context;
    }


    public async Task<StoreEntity> GetStore(StoreEntity model) => await context.Store.FirstOrDefaultAsync(
        Store =>
            Store.User.id == model.UserId);


    public async Task<List<StoreEntity>> GetAll() =>
          await context.Store
                    .Include(user => user.User)
                    .ToListAsync();

    public async Task<bool> CreateStore(StoreEntity model)
    {
        model.id = Guid.NewGuid();
        await Add(model);
        return true;
    }

    public async Task<StoreEntity> UpdateStore(StoreEntity map)
    {
        map.UdateAt = DateTime.Now;
        await AddOrUpdateAsync(map);
        return await GetByIdAsync(map.id);
    }

    public async Task<List<StoreEntity>> GetStoreByUserId(Guid userId) =>
        await context.Store.Where(u => u.UserId == userId).ToListAsync();

    public async Task<bool> DeleteStore(Guid Store_id) =>
        await Delete(await context.Store.FirstOrDefaultAsync(c => c.id == Store_id));
}