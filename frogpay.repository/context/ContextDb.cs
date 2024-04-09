using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }
    public virtual DbSet<UserEntity> User { get; set; } = null;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            // entity.ToTable("tb_user");
            entity.HasKey(p => p.Id);

        });
    }
    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();
        
        return await base.SaveChangesAsync();

    }
}