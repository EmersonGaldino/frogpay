using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace frogpay.repository.context
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(p => p.Id);

            });
        }
        
        public async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();
        
            return await base.SaveChangesAsync();

        }
    }
}