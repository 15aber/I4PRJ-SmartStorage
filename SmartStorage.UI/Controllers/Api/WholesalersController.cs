using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class WholesalersController : ApiController
  {
    private readonly IWholesalerService _service;
    private readonly ITransactionService _transactionService;

    public WholesalersController(IWholesalerService service, ITransactionService transactionService)
    {
      _service = service;
      _transactionService = transactionService;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetWholesalers()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    public IHttpActionResult GetWholesalerTransactions()
    {
      var entityDto = _transactionService.GetAllRestock();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IHttpActionResult DeleteWholesaler(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}