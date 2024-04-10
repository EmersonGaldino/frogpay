using System.Threading.Tasks;
using frogpay.domain.Entity.User;

namespace frogpay.application.Interface.User;

public interface IUserAppService
{
    Task<UserEntity> GetUser(UserEntity model);
}