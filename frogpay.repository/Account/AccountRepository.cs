using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Entity.Pagination;
using frogpay.domain.Repositories.IRepository.Account;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace frogpay.repository.Account;

public class AccountRepository : BaseRepository<DataBankEntity>, IAccountRepository
{
    private readonly ContextDb context;

    public AccountRepository(ContextDb context) : base(context)
    {
        this.context = context;
    }

    public async Task<DataBankEntity> GetAccount(DataBankEntity model) => await context.Account.FirstOrDefaultAsync(
        account =>
            account.User.id == model.UserId);


    public async Task<List<DataBankEntity>> GetAll()
    {
        var data = await context.Account
            .Include(user => user.User)
            .ToListAsync();
        
        // var result = await pagination.GetPaginatedData<DataBankEntity>(
        //     context,
        //     2 ,
        //     1,
        //     filter: x=> x.UserId == x.UserId,
        //     orderBy: o => o.OrderBy(x =>x.UserId));
        return data;
    }

    public async Task<bool> CreateAccount(DataBankEntity model)
    {
        model.id = Guid.NewGuid();
        await Add(model);
        return true;
    }

    public async Task<DataBankEntity> UpdateAccount(DataBankEntity map)
    {
        map.UdateAt = DateTime.Now;
        await AddOrUpdateAsync(map);
        return await GetByIdAsync(map.id);
    }

    public async Task<DataBankEntity> GetAccountByUserId(Guid userId) =>
        await context.Account.FirstOrDefaultAsync(u => u.UserId == userId);

    public async Task<bool> DeleteAccount(Guid account_id) =>
        await Delete(await context.Account.FirstOrDefaultAsync(c => c.id == account_id));
    
    
    
}