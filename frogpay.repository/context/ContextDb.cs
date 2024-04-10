using System.Threading.Tasks;
using frogpay.domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace frogpay.repository.context;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(
            builder
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(
                    LoggerFactory.Create(builder => builder.AddConsole() ))
            );
    }
    public virtual DbSet<UserEntity> User { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>().ToTable("tb_user");
    }
    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();
        
        return await base.SaveChangesAsync();

    }
    
}