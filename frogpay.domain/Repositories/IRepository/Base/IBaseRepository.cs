using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace frogpay.domain.Repositories.IRepository.Base;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IList<TEntity>> GetAllAsync();
    Task AddOrUpdateAsync(TEntity model);
}