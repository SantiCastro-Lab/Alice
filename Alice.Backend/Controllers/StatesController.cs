using Alice.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alice.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : GenericController<State>
    {
        public StatesController(UnitOfWork.Interfaces.IGenericUnitOfWork<State> unitOfWork) : base(unitOfWork)
        {
        }
    }
}