using Alice.Backend.UnitOfWork.Interfaces;
using Alice.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alice.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : GenericController<State>
    {
        private readonly IStatesUnitOfWork _statesUnitOfWork;

        public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
        {
            _statesUnitOfWork = statesUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var response = await _statesUnitOfWork.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _statesUnitOfWork.GetByIdAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }
    }
}