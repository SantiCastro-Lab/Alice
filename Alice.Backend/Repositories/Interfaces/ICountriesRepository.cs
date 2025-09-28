using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<Country?>> GetByIdAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAllAsync();

    Task<ActionResponse<IEnumerable<Country>>> GetPagedAsync(PaginationDTO pagination);
}
