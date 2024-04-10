using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Address;
using frogpay.domain.Repositories.IRepository.Address;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.Address;

public class AddressRepository : BaseRepository<AddressEntity>,IAddressRepository
{
    private readonly ContextDb context;
    public AddressRepository(ContextDb context) :base(context)
    {
        this.context = context;
    }

    public async Task<AddressEntity> GetAddress(AddressEntity model) => await context.Address.FirstOrDefaultAsync(
        account =>
            account.User.id == model.UserId);
    public async Task<List<AddressEntity>> GetAll()
    {
        var data = await context.Address
            .Include(user => user.User)
            .ToListAsync();
        return data;
    }

    public async Task<bool> CreateAddress(AddressEntity model)
    {
        model.id = Guid.NewGuid();
        await Add(model);
        return true;
    }

    public async Task<AddressEntity> UpdateAddress(AddressEntity map)
    {
        map.UdateAt = DateTime.Now;
        await AddOrUpdateAsync(map);
        return await GetByIdAsync(map.id);
    }

    public async Task<AddressEntity> GetAddressByUserId(Guid userId) =>
        await context.Address.Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == userId);

    public async Task<bool> DeleteAddress(Guid account_id) =>
        await Delete(await context.Address.FirstOrDefaultAsync(c => c.id == account_id));
}