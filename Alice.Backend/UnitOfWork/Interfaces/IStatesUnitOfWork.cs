using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Interfaces;

public interface IStatesUnitOfWork
{
    public Task<ActionResponse<IEnumerable<State>>> GetAllAsync();

    public Task<ActionResponse<State?>> GetByIdAsync(int id);

    public Task<ActionResponse<IEnumerable<State>>> GetPagedAsync(PaginationDTO pagination);

    public Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination);
}