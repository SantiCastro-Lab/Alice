using Alice.Backend.Repositories.Interfaces;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Implementations;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStatesRepository _statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAllAsync() =>
        await _statesRepository.GetAllAsync();

    public override async Task<ActionResponse<State?>> GetByIdAsync(int id) =>
        await _statesRepository.GetByIdAsync(id);

    public override async Task<ActionResponse<IEnumerable<State>>> GetPagedAsync(PaginationDTO pagination) =>
        await _statesRepository.GetPagedAsync(pagination);

    public override async Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination) =>
        await _statesRepository.GetCountAsync(pagination);
}