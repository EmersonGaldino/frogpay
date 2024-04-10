

using System.Threading.Tasks;
using frogpay.domain.Entity.User;

public interface IUserService
{
    Task<UserEntity> GetUser(UserEntity model);
}