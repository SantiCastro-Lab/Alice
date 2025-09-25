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

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country
            {
                Name = "Colombia",
                States = new List<State>
                {
                    new State
                    {
                        Name = "Antioquia",
                        Cities = new List<City>
                        {
                            new City { Name = "Medellín" },
                            new City { Name = "Envigado" },
                            new City { Name = "Bello" },
                            new City { Name = "Itagüí" },
                            new City { Name = "Rionegro" },
                            new City { Name = "Caldas" },
                            new City { Name = "Copacabana" },
                            new City { Name = "Girardota" },
                            new City { Name = "La Estrella" },
                            new City { Name = "Sabaneta" }
                        }
                    },
                    new State
                    {
                        Name = "Cundinamarca",
                        Cities = new List<City>
                        {
                            new City { Name = "Bogotá D.C." },
                            new City { Name = "Soacha" },
                            new City { Name = "Chía" },
                            new City { Name = "Zipaquirá" },
                            new City { Name = "Facatativá" },
                            new City { Name = "Mosquera" },
                            new City { Name = "Madrid" },
                            new City { Name = "Funza" },
                            new City { Name = "Girardot" },
                            new City { Name = "La Calera" }
                        }
                    }
                }
            });
            _context.Countries.Add(new Country
            {
                Name = "Estados Unidos",
                States = new List<State>
                {
                    new State
                    {
                        Name = "Florida",
                        Cities = new List<City>
                        {
                            new City { Name = "Miami" },
                            new City { Name = "Orlando" },
                            new City { Name = "Tampa" },
                            new City { Name = "Jacksonville" },
                            new City { Name = "Hialeah" },
                            new City { Name = "Tallahassee" },
                            new City { Name = "Port St. Lucie" },
                            new City { Name = "Cape Coral" },
                            new City { Name = "Fort Lauderdale" },
                            new City { Name = "Pembroke Pines" }
                        }
                    },
                    new State
                    {
                        Name = "Texas",
                        Cities = new List<City>
                        {
                            new City { Name = "Houston" },
                            new City { Name = "San Antonio" },
                            new City { Name = "Dallas" },
                            new City { Name = "Austin" },
                            new City { Name = "Fort Worth" },
                            new City { Name = "El Paso" },
                            new City { Name = "Arlington" },
                            new City { Name = "Corpus Christi" },
                            new City { Name = "Plano" },
                            new City { Name = "Laredo" }
                        }
                    }
                }
            });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Sueros" });
            _context.Categories.Add(new Category { Name = "Ropa y Fajas" });
            await _context.SaveChangesAsync();
        }
    }
}