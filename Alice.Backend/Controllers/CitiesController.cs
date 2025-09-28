using Alice.Backend.UnitOfWork.Implementations;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.DTOs;
using Alice.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alice.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    private readonly ICitiesUnitOfWork _citiesUnitOfWork;

    public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : base(unitOfWork)
    {
        _citiesUnitOfWork = citiesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetPagedAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _citiesUnitOfWork.GetPagedAsync(pagination);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }
    [HttpGet("count")]
    public override async Task<IActionResult> GetCountAsync([FromQuery] PaginationDTO pagination)
    {
        var response = await _citiesUnitOfWork.GetCountAsync(pagination);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }
}