using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.Controllers.Api
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
    public IHttpActionResult DeleteProduct(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}