using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using frogpay.domain.Repositories.IRepository.User;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.User;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly ContextDb context;

    public UserRepository(ContextDb context): base(context)
    {
        this.context = context;
    }

    public async Task<UserEntity> GetUser(UserEntity model) =>
            await context.User.FirstOrDefaultAsync(user =>
                user.Email == model.Email && user.Password == model.Password);


    public async Task<List<UserEntity>> GetAll()
    {
        var data = await context.User
            .Include(store => store.Stories)
            .ToListAsync();
        return data;
    } 
}