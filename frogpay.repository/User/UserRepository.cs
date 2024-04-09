using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using frogpay.domain.Repositories.IRepository.User;
using frogpay.repository.context;

namespace frogpay.repository.User;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly ContextDb context;

    public UserRepository(ContextDb context): base(context)
    {
        this.context = context;
    }

    public Task<UserEntity> GetUser(UserEntity model)
    {
        throw new System.NotImplementedException();
    }

    public Task<UserEntity> GetAll()
    {
        throw new System.NotImplementedException();
    }
}