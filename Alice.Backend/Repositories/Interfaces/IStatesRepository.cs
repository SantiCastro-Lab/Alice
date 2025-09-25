using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.Repositories.Interfaces;

public interface IStatesRepository
{
    public Task<ActionResponse<IEnumerable<State>>> GetAllAsync();

    public Task<ActionResponse<State?>> GetByIdAsync(int id);
}