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
    public async Task<DataBankEntity> GetAccount(DataBankEntity model) => await service.GetAccount(model);
    
    public async Task<List<DataBankEntity>> GetAll() => await service.GetAll();
    
    public async Task<bool> CreateAccount(DataBankEntity model) => await service.CreateAccount(model);
    
    public async Task<DataBankEntity> UpdateAccount(DataBankEntity map) => await service.UpdateAccount(map);
    
    public async Task<DataBankEntity> GetAccountByUserId(Guid userId) => await service.GetAccountByUserId(userId);
    
    public async Task<bool> DeleteAccount(Guid userId) => await service.DeleteAccount(userId);

}