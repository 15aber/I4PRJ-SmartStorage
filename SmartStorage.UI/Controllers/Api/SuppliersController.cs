using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class SuppliersController : ApiController
  {
    private readonly ISupplierService _service;
    private readonly ITransactionService _transactionService;

    public SuppliersController(ISupplierService service, ITransactionService transactionService)
    {
      _service = service;
      _transactionService = transactionService;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetSuppliers()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    public IHttpActionResult GetSupplierTransactions()
    {
      var entityDto = _transactionService.GetAllRestock();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IHttpActionResult DeleteSupplier(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}