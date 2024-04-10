using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Repositories.IRepository.Base;

namespace frogpay.domain.Repositories.IRepository.Account;

public interface IAccountRepository : IBaseRepository<DataBankEntity>
{
    Task<DataBankEntity> GetAccount(DataBankEntity model);
    Task<List<DataBankEntity>> GetAll();
    Task<bool> CreateAccount(DataBankEntity model);
    Task<DataBankEntity> UpdateAccount(DataBankEntity map);
    Task<DataBankEntity> GetAccountByUserId(Guid userId);
    Task<bool> DeleteAccount(Guid userId);
}