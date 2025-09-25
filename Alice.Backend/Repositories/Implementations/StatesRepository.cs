using Alice.Backend.Data;
using Alice.Backend.Repositories.Interfaces;
using Alice.Shared.Entities;
using Alice.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Repositories.Implementations;

public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAllAsync()
    {
        var states = await _context.States
            .Include(c => c.Cities)
            .ToListAsync();
        return new ActionResponse<IEnumerable<State>>
        {
            IsSuccess = true,
            Result = states
        };
    }

    public override async Task<ActionResponse<State?>> GetByIdAsync(int id)
    {
        var state = await _context.States
            .Include(s => s.Cities)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (state == null)
        {
            return new ActionResponse<State?>
            {
                Message = "El estado no existe."
            };
        }
        return new ActionResponse<State?>
        {
            IsSuccess = true,
            Result = state
        };
    }
}