using System.Threading.Tasks;
using frogpay.domain.Entity.Bank;
using frogpay.domain.Entity.Store;
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
    public virtual DbSet<StoreEntity> Store { get; set; }
    public virtual DataBankEntity Account { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StoreEntity>()
            .HasOne(s => s.user)
            .WithMany(a => a.Stores)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<DataBankEntity>()
            .HasKey(d => d.UserId);
        modelBuilder.Entity<DataBankEntity>()
            .HasOne(d => d.User)
            .WithOne(u => u.Account)
            .HasForeignKey<DataBankEntity>(d => d.UserId);
    }
    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();
        
        return await base.SaveChangesAsync();

    }
    
}