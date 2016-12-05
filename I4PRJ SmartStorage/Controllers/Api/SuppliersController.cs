using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.Controllers.Api
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
      var wholesalerDto = _service.GetAllActive();

      if (wholesalerDto == null) return NotFound();

      return Ok(wholesalerDto);
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