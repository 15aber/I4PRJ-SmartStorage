using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class SuppliersController : ApiController
  {
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
    {
      _service = service;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetSuppliers()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    public IHttpActionResult DeleteSupplier(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}