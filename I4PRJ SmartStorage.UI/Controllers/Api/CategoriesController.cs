using System.Web.Http;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;

namespace SmartStorage.UI.Controllers.Api
{
  public class CategoriesController : ApiController
  {
    private readonly ICategoryService _service;

    public CategoriesController()
      : this(new CategoryService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public CategoriesController(ICategoryService service)
    {
      _service = service ?? new CategoryService(new UnitOfWork(new ApplicationDbContext()));
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetCategories()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    public IHttpActionResult DeleteCategory(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}