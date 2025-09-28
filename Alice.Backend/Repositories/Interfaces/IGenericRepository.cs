using Alice.Shared.DTOs;
using Alice.Shared.Responses;

namespace Alice.Backend.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<ActionResponse<IEnumerable<T>>> GetAllAsync();

    Task<ActionResponse<T?>> GetByIdAsync(int id);

    Task<ActionResponse<IEnumerable<T>>> GetPagedAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination);

    Task<ActionResponse<T?>> AddAsync(T entity);

    Task<ActionResponse<T?>> UpdateAsync(int? id, T entity);

    Task<ActionResponse<bool>> DeleteAsync(int id);
}