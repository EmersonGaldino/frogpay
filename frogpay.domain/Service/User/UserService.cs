using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using frogpay.domain.Repositories.IRepository.User;

namespace frogpay.domain.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<UserEntity> GetUser(UserEntity model) => await repository.GetUser(model);

}