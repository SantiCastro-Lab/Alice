using Alice.Backend.Data;
using Alice.Backend.Helpers;
using Alice.Backend.Repositories.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetPagedAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(c => c.State!.Id == pagination.Id)
            .AsQueryable();

        return new ActionResponse<IEnumerable<City>>
        {
            IsSuccess = true,
            Result = await queryable
                .OrderBy(c => c.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(c => c.State!.Id == pagination.Id)
            .AsQueryable();
        double count = await queryable.CountAsync();    
        return new ActionResponse<int>
        {
            IsSuccess = true,
            Result = (int)count
        };
    }
}