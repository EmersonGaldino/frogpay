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

    public async Task<DataBankEntity> GetAccount(DataBankEntity model)
    {
        var account = await GetAccountByUserId(model.UserId);
        return account == null ? null : await repository.GetAccount(model);
    }

    public async Task<List<DataBankEntity>> GetAll() => await repository.GetAll();


    public async Task<bool> CreateAccount(DataBankEntity model)
    {
        var account = await GetAccountByUserId(model.UserId);
        return account != null ? false : await repository.CreateAccount(model);
    }

    public async Task<DataBankEntity> UpdateAccount(DataBankEntity map, Guid account_id)
    {
        map.id = account_id;
        return await repository.UpdateAccount(map);
    }
    
    public async Task<DataBankEntity> GetAccountByUserId(Guid userId) => await repository.GetAccountByUserId(userId);

    public async Task<bool> DeleteAccount(Guid account_id) =>
       await repository.DeleteAccount(account_id);
}