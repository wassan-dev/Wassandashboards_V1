using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Wassandashboard.Data
{
    public class DbContextFactory : IDbContextFactory<DashboardDbContext>
    {
        private readonly DbContextOptions<DashboardDbContext> _options;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbContextFactory(DbContextOptions<DashboardDbContext> options, IHttpContextAccessor httpContextAccessor)
        {
            _options = options;
            _httpContextAccessor = httpContextAccessor;
        }

        public DashboardDbContext CreateDbContext()
        {
            return new DashboardDbContext(_options, _httpContextAccessor);
        }
    }
}
