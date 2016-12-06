using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;

namespace I4PRJ_SmartStorage.UI.Controllers.Api
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