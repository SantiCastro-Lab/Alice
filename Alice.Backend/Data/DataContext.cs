using Alice.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasIndex(indexExpression: c => c.Name).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(indexExpression: c => c.Name).IsUnique();
    }
}