using Alice.Shared.Entities;

namespace Alice.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country { Name = "Colombia" });
            _context.Countries.Add(new Country { Name = "Mexico" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Sueros" });
            _context.Categories.Add(new Category { Name = "Ropa y Fajas" });
            await _context.SaveChangesAsync();
        }
    }
}