

using System.Collections.Generic;
using System.Threading.Tasks;
using frogpay.domain.Entity.User;

public interface IUserService
{
    Task<UserEntity> GetUser(UserEntity model);
    Task<List<UserEntity>> GetAllUsers();
    Task<bool> CreateUser(UserEntity model);
}