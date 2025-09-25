using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Country>>> GetAllAsync();

    Task<ActionResponse<Country?>> GetByIdAsync(int id);
}