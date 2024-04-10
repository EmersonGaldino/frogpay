using System.Threading.Tasks;
using frogpay.application.Interface.User;
using frogpay.domain.Entity.User;

namespace frogpay.application.AppService.User;

public class UserAppService : IUserAppService
{
    private IUserService service;

    public UserAppService(IUserService service)
    {
        this.service = service;
    }

    public async Task<UserEntity> GetUser(UserEntity model) => await service.GetUser(model);

}