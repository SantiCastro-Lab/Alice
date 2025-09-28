using Alice.Backend.Repositories.Interfaces;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Implementations;

public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
{
    private readonly ICitiesRepository _citiesRepository;

    public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
    {
        _citiesRepository = citiesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetPagedAsync(PaginationDTO pagination) => 
        await _citiesRepository.GetPagedAsync(pagination);

    public override async Task<ActionResponse<int>> GetCountAsync(PaginationDTO pagination) => 
        await _citiesRepository.GetCountAsync(pagination);
}
