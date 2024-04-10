using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Repositories.IRepository.Account;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.Account;

public class AccountRepository : BaseRepository<DataBankEntity>, IAccountRepository
{
    private DbContext context;
    public AccountRepository(ContextDb context) : base(context)
    {
        this.context = context;
    }

    public Task<DataBankEntity> GetAccount(DataBankEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<List<DataBankEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAccount(DataBankEntity model)
    {
        throw new NotImplementedException();
    }

    public Task<DataBankEntity> UpdateAccount(DataBankEntity map)
    {
        throw new NotImplementedException();
    }

    public Task<DataBankEntity> GetAccountByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Guid userId)
    {
        throw new NotImplementedException();
    }
}