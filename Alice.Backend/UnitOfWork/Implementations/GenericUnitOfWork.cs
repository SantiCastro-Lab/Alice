using Alice.Backend.Repositories.Implementations;
using Alice.Backend.Repositories.Interfaces;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<ActionResponse<T?>> AddAsync(T entity) => await _repository.AddAsync(entity);

    public virtual async Task<ActionResponse<bool>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync() => await _repository.GetAllAsync();

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetPagedAsync(PaginationDTO pagination) => await _repository.GetPagedAsync(pagination);
    
    public virtual async Task<ActionResponse<T?>> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public virtual async Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination) => await _repository.GetCountAsync(pagination);

    public virtual async Task<ActionResponse<T?>> UpdateAsync(int id, T entity) => await _repository.UpdateAsync(id, entity);
}