using frogpay.domain.Entity.Base;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository;

public class BaseRepository<TEntity> : IBaserepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ContextDb context;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(ContextDb context)
    {
        this.context = context;
        DbSet = context.Set<TEntity>();
    }
    
    
}