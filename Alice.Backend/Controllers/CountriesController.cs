using Alice.Backend.Data;
using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alice.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : GenericController<Country>
{
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;

    public CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountriesUnitOfWork countriesUnitOfWork)
        : base(unitOfWork)
    {
        _countriesUnitOfWork = countriesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAllAsync()
    {
        var response = await _countriesUnitOfWork.GetAllAsync();
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await _countriesUnitOfWork.GetByIdAsync(id);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}

//public class CountriesController : ControllerBase
//{
//    private readonly DataContext _context;

//    public CountriesController(DataContext context)
//    {
//        _context = context;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetCountries()
//    {
//        var countries = await _context.Countries.OrderBy(c => c.Name).ToListAsync();
//        return Ok(countries);
//    }

//    [HttpGet("{id:int}")]
//    public async Task<IActionResult> GetCountry(int id)
//    {
//        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
//        if (country == null)
//        {
//            return NotFound();
//        }
//        return Ok(country);
//    }

//    [HttpPost]
//    public async Task<IActionResult> AddCountry([FromBody] Country country)
//    {
//        if (country == null)
//        {
//            return BadRequest("El país es nulo.");
//        }
//        var existingCountry = await _context.Countries
//            .FirstOrDefaultAsync(c => c.Name.ToLower() == country.Name.ToLower());
//        if (existingCountry != null)
//        {
//            return BadRequest("Ya existe un país con el mismo nombre.");
//        }
//        _context.Countries.Add(country);
//        await _context.SaveChangesAsync();
//        return Ok(country);
//    }

//    [HttpPut("{id:int}")]
//    public async Task<IActionResult> UpdateCountry(int id, [FromBody] Country country)
//    {
//        if (country == null || id != country.Id)
//        {
//            return BadRequest("El país es nulo o el id no coincide.");
//        }
//        var existingCountry = await _context.Countries
//            .FirstOrDefaultAsync(c => c.Name.ToLower() == country.Name.ToLower() && c.Id != id);
//        if (existingCountry != null)
//        {
//            return BadRequest("Ya existe un país con el mismo nombre.");
//        }
//        _context.Countries.Update(country);
//        await _context.SaveChangesAsync();
//        return Ok(country);
//    }

//    [HttpDelete("{id:int}")]
//    public async Task<IActionResult> DeleteCountry(int id)
//    {
//        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
//        if (country == null)
//        {
//            return NotFound();
//        }
//        _context.Countries.Remove(country);
//        await _context.SaveChangesAsync();
//        return NoContent();
//    }
//}