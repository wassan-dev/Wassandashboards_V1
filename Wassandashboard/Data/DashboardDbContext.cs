using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wassandashboard.Data.Entities;

namespace Wassandashboard.Data
{
    public class DashboardDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardDbContext(DbContextOptions<DashboardDbContext> options, IHttpContextAccessor httpContextAccessor)
       : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Important for IdentityDbContext            

            // Apply global query filter for soft-delete
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                    var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

      


        public DbSet<Projects> Projects { get; set; }
        public DbSet<UserProjects> UserProjects { get; set; }

        public DbSet<Regions> Regions { get; set; }
    }
}
