using System.Collections.Generic;
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
    public async Task<List<UserEntity>> GetAllUsers() => await service.GetAllUsers();
    public async Task<bool> Createsuer(UserEntity model) => await service.CreateUser(model);

}