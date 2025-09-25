using Alice.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasIndex(indexExpression: c => c.Name).IsUnique();
        modelBuilder.Entity<City>().HasIndex(indexExpression: c => new { c.StateId, c.Name }).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(indexExpression: c => c.Name).IsUnique();
        modelBuilder.Entity<State>().HasIndex(indexExpression: s => new { s.CountryId, s.Name }).IsUnique();
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var foreignKeys = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys());
        foreach (var foreignKey in foreignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}