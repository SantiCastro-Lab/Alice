using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Interfaces;

public interface ICitiesUnitOfWork
{
    Task<ActionResponse<IEnumerable<City>>> GetPagedAsync(PaginationDTO pagination);
    Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination);
}
