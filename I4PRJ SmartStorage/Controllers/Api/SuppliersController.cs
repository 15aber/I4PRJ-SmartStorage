using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using System.Web.Http;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class SuppliersController : ApiController
  {
    private readonly ISupplierService _service;

    public SuppliersController()
      : this(new SupplierService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public SuppliersController(ISupplierService service)
    {
      _service = service ?? new SupplierService(new UnitOfWork(new ApplicationDbContext()));
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