using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.User;

namespace frogpay.application.Interface.User;

public interface IUserAppService
{
    Task<UserEntity> GetUser(UserEntity model);
    Task<List<UserEntity>> GetAllUsers();
    Task<bool> Createsuer(UserEntity model);
    Task<UserEntity> UpdateUser(UserEntity map, Guid idPessoa);
}