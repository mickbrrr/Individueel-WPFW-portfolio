
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
