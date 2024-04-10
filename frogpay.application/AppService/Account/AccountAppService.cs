using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.application.Interface.Account;
using frogpay.domain.Entity.Bank;

namespace frogpay.application.AppService.Account;

public class AccountAppService: IAccountAppService
{
    private readonly IAccountService service;
    public AccountAppService(IAccountService service)
    {
        this.service = service;
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