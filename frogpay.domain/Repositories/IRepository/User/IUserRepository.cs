using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using frogpay.domain.Repositories.IRepository.Base;

namespace frogpay.domain.Repositories.IRepository.User;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity> GetUser(UserEntity model);
    Task<List<UserEntity>> GetAll();
}