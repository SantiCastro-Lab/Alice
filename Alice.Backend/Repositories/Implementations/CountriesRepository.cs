using Alice.Backend.Data;
using Alice.Backend.Helpers;
using Alice.Backend.Repositories.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Repositories.Implementations;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAllAsync()
    {
        var countries = await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            IsSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<Country?>> GetByIdAsync(int id)
    {
        var country = await _context.Countries
            .Include(c => c.States!)
            .ThenInclude(s => s.Cities)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (country == null)
        {
            return new ActionResponse<Country?>
            {
                Message = "El país no existe."
            };
        }
        return new ActionResponse<Country?>
        {
            IsSuccess = true,
            Result = country
        };
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetPagedAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries
            .Include(c=> c.States)
            .AsQueryable();

        return new ActionResponse<IEnumerable<Country>>
        {
            IsSuccess = true,
            Result = await queryable
                .OrderBy(x=> x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }
}