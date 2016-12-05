using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class CategoriesController : ApiController
  {
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
      _service = service;
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