using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.Repositories.Interfaces;

public interface ICitiesRepository
{
    Task<ActionResponse<IEnumerable<City>>> GetPagedAsync(PaginationDTO pagination);
    Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination);
}
