using Alice.Backend.Repositories.Interfaces;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Alice.Shared.Responses;

namespace Alice.Backend.UnitOfWork.Implementations;

public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository
   countriesRepository) : base(repository)
    {
        _countriesRepository = countriesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAllAsync() => await _countriesRepository.GetAllAsync();

    public override async Task<ActionResponse<Country?>> GetByIdAsync(int id) => await _countriesRepository.GetByIdAsync(id);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetPagedAsync(PaginationDTO pagination) => await _countriesRepository.GetPagedAsync(pagination);
}