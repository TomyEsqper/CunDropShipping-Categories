using Microsoft.EntityFrameworkCore;
using CunDropShipping_Categories.infrastructure.Entity;

namespace CunDropShipping_Categories.infrastructure.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<CategoriesEntity> categories { get; set; } = null!;
}