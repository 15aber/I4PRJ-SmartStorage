using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class ProductsController : ApiController
  {
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
      _service = service;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetProducts()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    public IHttpActionResult GetProductsOfCategory(int id)
    {
      var entityDto = _service.GetAllActiveOfCategory(id);

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IHttpActionResult DeleteProduct(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}