using Alice.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alice.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : GenericController<Category>
{
    public CategoriesController(UnitOfWork.Interfaces.IGenericUnitOfWork<Category> unitOfWork) : base(unitOfWork)
    {
    }
}