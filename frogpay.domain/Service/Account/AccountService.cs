using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Repositories.IRepository.Account;

namespace frogpay.domain.Service.Account;

public class AccountService : IAccountService
{
    private readonly IAccountRepository repository;
    public AccountService(IAccountRepository repository)
    {
        this.repository = repository;
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