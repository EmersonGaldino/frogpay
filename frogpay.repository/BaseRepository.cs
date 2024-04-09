using System;
using frogpay.domain.Entity.Base;
using frogpay.repository.context;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ContextDb context;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(ContextDb context)
    {
        this.context = context;
        DbSet = context.Set<TEntity>();
    }

    public void Dispose() => GC.SuppressFinalize(this);
}