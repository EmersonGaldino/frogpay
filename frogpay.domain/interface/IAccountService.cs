using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;


public interface IAccountService
{
    Task<DataBankEntity> GetAccount(DataBankEntity model);
    Task<List<DataBankEntity>> GetAll();
    Task<bool> CreateAccount(DataBankEntity model);
    Task<DataBankEntity> UpdateAccount(DataBankEntity map);
    Task<DataBankEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid userId);
}